using System;
using RLNET;

namespace roguelike
{
	public class Player
	{

		public Player (int x, int y){
			this.x = x;
			this.y = y;
		}

		public void update(){
		}

		public int x{ get; set; }
		public int y{ get; set; }
		public int health{ get; set; }

		//TODO: Look into how to pass paramteters to this method
		//If I could specify somehow that the cell should be passed, I can get rid
		//of a level manager reference.
		public void OnRootConsoleUpdate(object sender, UpdateEventArgs e){
			RLKeyPress keypress = MainClass.getConsole().Keyboard.GetKeyPress ();
			Screen screen = MainClass.getScreen ();
			if (keypress != null) {
				if (keypress.Key == RLKey.W) {
					if (MainClass.getLevelManager().getIMap (0).GetCell (x, y - 1).IsWalkable)
						y -= 1;

				}
				if (keypress.Key == RLKey.S) {
					if (MainClass.getLevelManager().getIMap (0).GetCell (x, y + 1).IsWalkable)
						y += 1;

				}
				if (keypress.Key == RLKey.A) {
					if (MainClass.getLevelManager().getIMap (0).GetCell (x - 1, y).IsWalkable)
						x -= 1;

				}
				if (keypress.Key == RLKey.D) {
					if (MainClass.getLevelManager().getIMap (0).GetCell (x + 1, y).IsWalkable)
						x += 1;

				}

				if (keypress.Key == RLKey.E) {
					Chest chest = MainClass.getChestManager().isChestInCell (x, y);
					if (chest != null) {
						chest.openChest ();
					}
				}
			}
		}

		public void OnRootConsoleRender(object sender, UpdateEventArgs e){
			MainClass.getLevelManager().getIMap (0).ComputeFov (x, y, 60, true);
			MainClass.getConsole().Set( x, y, RLColor.LightGreen, null, '@' );

		}
}
}

