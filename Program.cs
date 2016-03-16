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
		private static LevelManager lm;


		public static void Main (string[] args){
			screen = new Screen ();
			lm = new LevelManager ();
			lm.generate ();
			EntityManager em = new EntityManager (screen);
			chestManager = new ChestManager (em, 6);
		 	
			player = new Player (25,25);
			em.generateLadders (2);
			console = screen.getConsole();
			console.Render += screen.beginRootConsoleRender;

			console.Render += screen.OnRootConsoleRender;
			console.Render += player.OnRootConsoleRender;
			console.Render += chestManager.OnRootConsoleRender;

			console.Render += em.OnRootConsoleRender;

			console.Render += screen.endRootConsoleRender;

			console.Update += player.OnRootConsoleUpdate;

			console.Run ();
		
		}

		//I hate all of these static getters... TODO refactor this garbage away.
		public static RLRootConsole getConsole(){
			return console;
		}

		public static Screen getScreen(){
			return screen;
		}

		public static LevelManager getLevelManager(){
			return lm;
		}

		public static ChestManager getChestManager(){
			return chestManager;
		}

	}
}
