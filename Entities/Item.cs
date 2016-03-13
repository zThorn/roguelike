using System;
using RLNET;
using RogueSharp;

namespace roguelike
{
	public class Item : IDrawable
	{
		public bool equippable;
		public int value;

		public RLColor Color { get; set; }
		public char Symbol { get; set; }
		public int x { get; set; }
		public int y { get; set; }

		public void Draw(RLConsole console, IMap map){
			console.Set (x, y, Color, null, Symbol);

		}
		 

	}
}

