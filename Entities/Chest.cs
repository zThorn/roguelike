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
		public RLColor Color { get; set; }

		public Chest (int x, int y){
			this.x = x;
			this.y = y;
			this.Symbol = 'C';
			this.Color = RLColor.Yellow;
		}

		public void openChest(){
			opened = true;
			Symbol = 'O';
		}
		public void Draw(RLConsole console, IMap map){
			console.Set (x, y, Color, null, Symbol);

		}
}
}
