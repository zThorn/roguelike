using System;
using C5;
using RLNET;
using RogueSharp.DiceNotation;

namespace roguelike
{
	public class EntityManager{
		public Screen screenReference{ get; set;}

		public EntityManager (Screen screen){
			this.screenReference = screen;
		}

		public ArrayList<Chest> generateChests(int limit){
			ArrayList<Chest> chestList = new ArrayList<Chest>();
			int counter = 0;
			for(int x = 0; x<Level.screenWidth; x++){
				for(int y=0; y<Level.screenHeight; y++){
					var ChestDice = Dice.Parse ("d64");

						if (ChestDice.Roll().Value == 20 && screenReference.getIMap().GetCell(x,y).IsWalkable && counter < limit) {
						Chest tempChest = new Chest (x, y);
						screenReference.getIMap().SetCellProperties( x, y, true, false, false );
						chestList.Add (tempChest);
						counter++;
					}
				}
			}
			return chestList;
		}





	}
}
