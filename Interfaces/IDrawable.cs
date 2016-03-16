using System;
using RLNET;
using RogueSharp;
namespace roguelike
{
	public interface IDrawable
	{
		RLColor Color { get; set; }
		char Symbol { get; set; }
		int x { get; set; }
		int y { get; set; }
		int z { get; set; }


		void Draw(RLConsole console, IMap map);
	}
}

