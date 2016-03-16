using System;
using C5;
using RogueSharp;
using RLNET;

namespace roguelike
{
	//TODO: This should be removed.  EntityManager should have a generic "Get Cell Occupants" method, and should have a generic renderer
	public class ChestManager
	{
		private ArrayList<Chest> chests;
		//TODO: Leaving this blank for now...there shouldnt ever be a default instance 
		public ChestManager (EntityManager iGen){
			
		}

		public ChestManager(EntityManager em,  int chestNumber){
			chests = new ArrayList<Chest> ();
		
			chests.AddAll(em.generateChests (6));
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
			IMap currentIMap = MainClass.getLevelManager ().getIMap ();
			foreach (var chest in chests) {
				if (chest.z == MainClass.getLevelManager().currentFloor && currentIMap.GetCell (chest.x, chest.y).IsInFov || currentIMap.GetCell (chest.x, chest.y).IsExplored) {
					chest.Draw (MainClass.getConsole(), currentIMap);
				}
			}
		}

			
	}
}

