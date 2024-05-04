namespace _2048
{
	public class HumanPlayer : IPlayer
	{
		public string PlayerType => "Human";
		public Direction GetMove(Game game)
		{
			System.ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);
			System.Console.SetCursorPosition(0, System.Console.CursorTop);
			System.Console.Write(new string(' ', System.Console.WindowWidth));
			switch (keyInfo.Key)
			{
				case System.ConsoleKey.UpArrow:
					return Direction.Up;
				case System.ConsoleKey.LeftArrow:
					return Direction.Left;
				case System.ConsoleKey.DownArrow:
					return Direction.Down;
				case System.ConsoleKey.RightArrow:
					return Direction.Right;
				case System.ConsoleKey.R:
					return Direction.Reset;
				case System.ConsoleKey.Q:
					return Direction.Quit;
				default:
					return GetMove(game);
			}
		}
	}
}
