namespace _2048
{
	class Program
	{
		static void Main()
		{
			Game game = new Game();
			IPlayer player = new HumanPlayer();
			while (!game.IsOver())
			{
				Direction move = player.GetMove(game);
				game.Update(move);
			}
		}
	}
}
