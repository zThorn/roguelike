using System;
using C5;
using RLNET;
using RogueSharp.DiceNotation;
using RogueSharp;

namespace roguelike
{
	public class EntityManager{
		public Screen screenReference{ get; set;}
		public ArrayList<Ladder> ladderList;
		public EntityManager (Screen screen){
			this.screenReference = screen;
		}

		public ArrayList<Chest> generateChests(int limit){
			ArrayList<Chest> chestList = new ArrayList<Chest>();
			int counter = 0;

			IMap currentMap = MainClass.getLevelManager ().getIMap ();
			for (int z = 0; z < MainClass.getLevelManager ().maxFloors; z++) {
				for (int x = 0; x < Level.screenWidth; x++) {
					for (int y = 0; y < Level.screenHeight; y++) {
						var ChestDice = Dice.Parse ("d12");
						if (ChestDice.Roll ().Value == 1 && currentMap.GetCell (x, y).IsWalkable && counter < limit) {
							Chest tempChest = new Chest (x, y, z);
							currentMap.SetCellProperties (x, y, true, false, false);

							chestList.Add (tempChest);
							counter++;
						}
					}
				}
			}
			return chestList;
		}

		public ArrayList<Ladder> generateLadders(int limit){
			ladderList = new ArrayList<Ladder>();
			int counter = 0;
			//This should be randomized
		
			for (int z = 0; z < MainClass.getLevelManager().maxFloors; z++) {
				IMap currentMap = MainClass.getLevelManager ().getIMap (z);
				for (int x = 0; x < Level.screenWidth; x++) {
					for (int y = 0; y < Level.screenHeight; y++) {
						var ChestDice = Dice.Parse ("d6");
							if (ChestDice.Roll().Value == 6 && currentMap.GetCell (x, y).IsWalkable && counter < limit) {
							Ladder tempLadder = new Ladder (x, y, z);
							currentMap.SetCellProperties (x, y, true, true, false);
							ladderList.Add (tempLadder);
							counter++;
						}
					}
				}	
			}
			return ladderList;
		}


		public void OnRootConsoleRender(object sender, UpdateEventArgs e ){
			IMap currentIMap = MainClass.getLevelManager ().getIMap ();
			foreach (var ladder in ladderList) {
				if (ladder.z == MainClass.getLevelManager().currentFloor && currentIMap.GetCell (ladder.x, ladder.y).IsInFov || currentIMap.GetCell (ladder.x, ladder.y).IsExplored) {
					ladder.Draw (MainClass.getConsole(), currentIMap);
				}
			}
	}
}

}