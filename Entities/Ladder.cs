using System;
using RLNET;
using RogueSharp;

namespace roguelike{
	
	public class Ladder : IDrawable{
		
		public Ladder (int x, int y, int z){
			this.x = x;
			this.y = y;
			this.z = z;
			this.Symbol = '%';
			this.Color = RLColor.Red;
		}

		public RLColor Color { get; set; }
		public char Symbol { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public int z { get; set; }

		public void Draw(RLConsole console, IMap map){
			console.Set (x, y, Color, null, Symbol);
		}
	}
}

