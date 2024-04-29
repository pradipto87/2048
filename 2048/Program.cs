namespace _2048
{
	class Program
	{
		public static void Main()
		{
			Game game = new Game();
			IPlayer player = new HumanPlayer();
			while (!game.GetIsOver())
			{
				game.Display();
				Direction move = player.GetMove(game);
				if (move == Direction.Quit)
					break;
				else if (move == Direction.Reset)
					game = new Game();
				else
					game.Update(move);
			}
		}
	}
}
