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
		}

		public void generate(){
			map = RogueSharp.Map.Create( new CaveMapCreationStrategy<Map>( Level.screenWidth, Level.screenHeight, 65, 4, 2 ) );
			console = new RLRootConsole ("terminal8x8.png", Level.screenWidth, Level.screenHeight, 8, 8, 1f, "Roguelike");
		/*
			This should be moved to the LevelManager class.  LevelManager should, in order --> generate the Maps --> add them
			to the ArrayList --> populate the level with items.  Screen should contain ONLY functionality related to the screen.
			Adding the update loop here is probably overstepping, it might make sense to move this to Player
		
		*/
		}


		public IMap getIMap(){ return map; }
		public RLRootConsole getConsole(){
			return console;
		}
		public static void setIMap(IMap im) { map = im;}


	}
}

