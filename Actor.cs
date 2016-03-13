using System;
namespace roguelike
{
	public class Actor
	{
		private int x;
		private int y;
		private int health;

		public Actor (int x, int y, int health){
			this.x = x;
			this.y = y;
			this.health = health;
		}

		public void Move(int x, int y){
			this.x = x;
			this.y = y;
		}

		public void Damage(int d){
			this.health -= d;
		}

}
}

