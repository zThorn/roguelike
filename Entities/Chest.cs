using System;
using RLNET;
using RogueSharp;


namespace roguelike
{
	public class Chest : IDrawable
	{
		private bool opened;
		public char Symbol { get; set; }

		public int x{ get; set; }
		public int y{ get; set;}
		public int z{ get; set;}

		public RLColor Color { get; set; }

		public Chest (int x, int y, int z){
			this.x = x;
			this.y = y;
			this.z = z;
			this.Symbol = 'C';
			this.Color = RLColor.Yellow;
			System.Console.WriteLine ("x: " + x + " y: " + y);

		}

		public void openChest(){
			opened = true;
			Symbol = 'O';
		}

		public void Draw(RLConsole console, IMap map){
			console.Set (x, y, Color, null, Symbol);
			MainClass.getConsole().Set( x, y, Color, null, Symbol );

		}
}
}
