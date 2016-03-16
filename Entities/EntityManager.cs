using System;
using C5;
using RLNET;
using RogueSharp.DiceNotation;
using RogueSharp;

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
			IMap currentMap = MainClass.getLevelManager ().getIMap (0);
			for(int x = 0; x<Level.screenWidth; x++){
				for(int y=0; y<Level.screenHeight; y++){
					var ChestDice = Dice.Parse ("d64");

						if (ChestDice.Roll().Value == 20 && currentMap.GetCell(x,y).IsWalkable && counter < limit) {
						Chest tempChest = new Chest (x, y, 0);
						currentMap.SetCellProperties( x, y, true, false, false );
						chestList.Add (tempChest);
						counter++;
					}
				}
			}
			return chestList;
		}

		public ArrayList<Ladder> generateLadders(int floors){
			ArrayList<Ladder> ladderList = new ArrayList<Ladder>();
			int counter = 0;
			//This should be randomized
			/*
			for (int z = 0; z < MainClass.getLevelManager().currentFloor; z++) {
				IMap currentMap = MainClass.getLevelManager ().getIMap (0);
				for (int x = 0; x < Level.screenWidth; x++) {
					for (int y = 0; y < Level.screenHeight; y++) {
						if (currentMap.GetCell (x, y).IsWalkable) {
							Ladder tempLadder = new Ladder (x, y, z);
							currentMap.SetCellProperties (x, y, true, true, false);
							ladderList.Add (tempLadder);
							counter++;
						}
					}
				}	
			}*/
			return ladderList;
		}





	}
}
