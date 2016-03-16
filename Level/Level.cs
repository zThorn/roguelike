using System;
using RogueSharp;

namespace roguelike
{
	public struct Level{
		public static readonly int screenWidth = 50;
		public static readonly int screenHeight = 50;
		public IMap map;

		public Level(IMap map){
			this.map = map;
		}
	}
}

