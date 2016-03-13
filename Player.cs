using System;

namespace roguelike
{
	public class Player
	{

		public Player (int x, int y){
			this.x = x;
			this.y = y;
		}

		public void update(){
		}

		public int x{ get; set; }
		public int y{ get; set; }
		public int health{ get; set; }
}
}

