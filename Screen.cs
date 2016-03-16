using System;
using RogueSharp;
using RLNET;
using RogueSharp.DiceNotation;

namespace roguelike
{
	public class Screen
	{
		
		public RLRootConsole console;

		//This class should hold all rendering & update loops I think...I should refactor.

		public Screen(){

			console = new RLRootConsole ("terminal8x8.png", Level.screenWidth, Level.screenHeight, 8, 8, 1f, "Roguelike");

		}

		public RLRootConsole getConsole(){
			return console;
		}

		public void beginRootConsoleRender(object sender, UpdateEventArgs e){
			MainClass.getConsole().Clear();
		}

		public void endRootConsoleRender(object sender, UpdateEventArgs e){
			console.Draw ();
		}

		public  void OnRootConsoleRender(object sender, UpdateEventArgs e){

			foreach ( var cell in MainClass.getLevelManager().getIMap (0).GetAllCells() )
			{
				// When a Cell is in the field-of-view set it to a brighter color
				if ( cell.IsInFov )
				{
					MainClass.getLevelManager().getIMap (0).SetCellProperties( cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true );
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
						//console.Set( cell.X, cell.Y, new RLColor( 30, 30, 30 ), null, '.' );
					}
					else
					{
						console.Set( cell.X, cell.Y, RLColor.Gray, null, '#' );
					}
				}
			}
				
		}



	}
}

