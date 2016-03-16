using System;
using C5;
using RogueSharp;
using RLNET;

namespace roguelike{
	
	public class LevelManager{
		
		private ArrayList<Level> levels;
		private int floorsToGenerate;
		public int currentFloor;

		public LevelManager (){
			currentFloor = 0;
			floorsToGenerate = 5;
			levels = new ArrayList<Level> ();
		}

		public void generate(){
			for (int i = 0; i < floorsToGenerate; i++) {
				IMap map = RogueSharp.Map.Create (new CaveMapCreationStrategy<Map> (Level.screenWidth, Level.screenHeight, 65, 4, 2));
				Level tempLevel = new Level (map);
				levels.Add (tempLevel);
			}

		}

		public IMap getIMap(int i){ return levels[i].map; }

	}
}

