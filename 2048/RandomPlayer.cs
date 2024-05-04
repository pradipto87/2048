namespace _2048
{
	public class RandomPlayer : IPlayer
	{
		private readonly System.Random random;
		public RandomPlayer() => random = new System.Random();
		public string PlayerType => "Random";
		public Direction GetMove(Game game)
		{
			return random.Next(4) switch
			{
				0 => Direction.Up,
				1 => Direction.Down,
				2 => Direction.Left,
				_ => Direction.Right
			};
		}
	}
}
