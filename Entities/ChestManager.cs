using System;
using C5;
using RogueSharp;
using RLNET;

namespace roguelike
{
	public class ChestManager
	{
		private ArrayList<Chest> chests;
		private EntityManager em;
		//TODO: Leaving this blank for now...there shouldnt ever be a default instance 
		public ChestManager (EntityManager iGen){
			
		}

		public ChestManager(EntityManager iGen,  int chestNumber){
			chests = new ArrayList<Chest> ();
			chests.AddAll(iGen.generateChests (6));
			this.em = iGen;
		}

		public void addChest(Chest chest){
			chests.Add (chest);
		}

		public Chest isChestInCell(int x, int y){
			foreach( var chest in chests)
				if ((chest.x == x && chest.y == y) || (chest.x == x-1 && chest.y == y) ||
					(chest.x == x+1 && chest.y == y) || (chest.x == x && chest.y == y-1) ||
					(chest.x == x && chest.y == y+1))
					return chest;
			return null;
		}

		private void openChest(){
		}

		public void OnRootConsoleRender(object sender, UpdateEventArgs e ){
			IMap currentIMap = MainClass.getLevelManager ().getIMap (0);
			foreach (var Chest in chests) {
				if (currentIMap.GetCell (Chest.x, Chest.y).IsInFov || currentIMap.GetCell (Chest.x, Chest.y).IsExplored) {
					Chest.Draw (MainClass.getConsole(), currentIMap);
				}
			}
		}

			
	}
}

