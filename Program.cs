using System;
using System.Collections;
using RogueSharp;
using RogueSharp.DiceNotation;
using RLNET;
using C5;


namespace roguelike
{
	class MainClass
	{

		private static RLRootConsole console;
		private static Player player;
		private static ChestManager chestManager;
		private static Screen screen;

		public static void Main (string[] args){
			screen = new Screen ();
			screen.generate();
			EntityManager iGen = new EntityManager (screen);
			chestManager = new ChestManager (iGen, 6);
			player = new Player (25,25);
			console = screen.getConsole();
			console.Render += OnRootConsoleRender;
			console.Update += OnRootConsoleUpdate;

			console.Run ();
		
		}

		private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e){
			RLKeyPress keypress = console.Keyboard.GetKeyPress ();

			if (keypress != null) {
				if (keypress.Key == RLKey.W) {
					if (screen.getIMap ().GetCell (player.x, player.y - 1).IsWalkable)
						player.y -= 1;
				
					}
				if (keypress.Key == RLKey.S) {
					if (screen.getIMap ().GetCell (player.x, player.y + 1).IsWalkable)
						player.y += 1;

				}
				if (keypress.Key == RLKey.A) {
					if (screen.getIMap ().GetCell (player.x - 1, player.y).IsWalkable)
						player.x -= 1;

				}
				if (keypress.Key == RLKey.D) {
					if (screen.getIMap ().GetCell (player.x + 1, player.y).IsWalkable)
						player.x += 1;

				}
				if (keypress.Key == RLKey.E) {
					Chest chest = chestManager.isChestInCell (player.x, player.y);
					if (chest != null) {
						chest.openChest ();
					}
				}
			}
		}

		private static void OnRootConsoleRender(object sender, UpdateEventArgs e){
			console.Clear ();
			screen.getIMap ().ComputeFov (player.x, player.y, 60, true);

			foreach ( var cell in screen.getIMap().GetAllCells() )
			{
				// When a Cell is in the field-of-view set it to a brighter color
				if ( cell.IsInFov )
				{
					screen.getIMap().SetCellProperties( cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true );
					if ( cell.IsWalkable )
					{
						 
						console.Set( cell.X, cell.Y, RLColor.Gray, null, '.' );
					}
					else
					{
						console.Set( cell.X, cell.Y, RLColor.LightGray, null, '#' );
					}
				}
				// If the Cell is not in the field-of-view but has been explored set it darker
				else if ( cell.IsExplored )
				{
					if ( cell.IsWalkable )
					{
						console.Set( cell.X, cell.Y, new RLColor( 30, 30, 30 ), null, '.' );
					}
					else
					{
						console.Set( cell.X, cell.Y, RLColor.Gray, null, '#' );
					}
				}
			}

			chestManager.drawChests ();

			console.Set( player.x, player.y, RLColor.LightGreen, null, '@' );
			console.Draw ();
		}

	}
}
