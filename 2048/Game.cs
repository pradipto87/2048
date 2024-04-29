namespace _2048
{
	public class Config
	{
		public static readonly int Rows = 4;
		public static readonly int Columns = 4;
	}
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right,
		Reset,
		Quit
	}
	public class Game
	{
		private int score;
		private int moveCount;
		private readonly int[,] board;
		private readonly System.Random random;
		public Game()
		{
			score = 0;
			moveCount = 0;
			board = new int[Config.Rows, Config.Columns];
			random = new System.Random();
			AddTile();
			AddTile();
		}
		public bool GetIsOver()
		{
			for (int i = 0; i < Config.Rows; ++i)
				for (int j = 0; j < Config.Columns; ++j)
					if (board[i, j] == 0)
						return false;
			return true;
		}

		private void AddTile()
		{
			System.Collections.Generic.List<(int, int)> emptyTiles = new System.Collections.Generic.List<(int, int)>();
			for (int i = 0; i < Config.Rows; ++i)
				for (int j = 0; j < Config.Columns; ++j)
					if (board[i, j] == 0)
						emptyTiles.Add((i, j));
			if (emptyTiles.Count > 0)
			{
				(int, int) tile = emptyTiles[random.Next(emptyTiles.Count)];
				board[tile.Item1, tile.Item2] = random.Next(10) < 9 ? 1 : 2;
			}
		}
		private void MoveSingle(int[] single)
		{
			// move tiles from right to left
			int last = 0;
			for (int i = 1; i < single.Length; ++i)
			{
				if (single[i] == 0)
					continue;
				int now = i;
				while (now > last)
				{
					if (single[now - 1] == 0)
					{
						single[now - 1] = single[now];
						single[now] = 0;
						--now;
					}
					else if (single[now - 1] == single[now])
					{
						++single[now - 1];
						single[now] = 0;
						last = now;
						--now;
						score += 1 << single[now];
					}
					else
					{
						now = last;
					}
				}
			}
		}
		public void Update(Direction dir)
		{
			switch (dir)
			{
				case Direction.Up:
					for (int j = 0; j < Config.Columns; ++j)
					{
						int[] single = new int[Config.Rows];
						for (int i = 0; i < Config.Rows; ++i)
							single[i] = board[i, j];
						MoveSingle(single);
						for (int i = 0; i < Config.Rows; ++i)
							board[i, j] = single[i];
					}
					break;
				case Direction.Down:
					for (int j = 0; j < Config.Columns; ++j)
					{
						int[] single = new int[Config.Rows];
						for (int i = 0; i < Config.Rows; ++i)
							single[i] = board[Config.Rows - i - 1, j];
						MoveSingle(single);
						for (int i = 0; i < Config.Rows; ++i)
							board[Config.Rows - i - 1, j] = single[i];
					}
					break;
				case Direction.Left:
					for (int i = 0; i < Config.Rows; ++i)
					{
						int[] single = new int[Config.Columns];
						for (int j = 0; j < Config.Columns; ++j)
							single[j] = board[i, j];
						MoveSingle(single);
						for (int j = 0; j < Config.Columns; ++j)
							board[i, j] = single[j];
					}
					break;
				case Direction.Right:
					for (int i = 0; i < Config.Rows; ++i)
					{
						int[] single = new int[Config.Columns];
						for (int j = 0; j < Config.Columns; ++j)
							single[j] = board[i, Config.Columns - j - 1];
						MoveSingle(single);
						for (int j = 0; j < Config.Columns; ++j)
							board[i, Config.Columns - j - 1] = single[j];
					}
					break;
			}
			++moveCount;
			AddTile();
		}
		public void Display()
		{
			System.Console.Clear();
			System.Console.WriteLine($"Score: {score}");
			System.Console.WriteLine($"Move Count: {moveCount}");
			System.Console.WriteLine();
			for (int j = 0; j < Config.Columns; ++j)
				System.Console.Write("+--------");
			System.Console.WriteLine("+");
			for (int i = 0; i < Config.Rows; ++i)
			{
				for (int j = 0; j < Config.Columns; ++j)
				{
					if (board[i, j] <= 0)
					{
						System.Console.Write("|        ");
					}
					else
					{
						int num = 1 << board[i, j];
						System.Console.Write("| ");
						System.Console.Write(System.String.Format("{0,6}", num));
						System.Console.Write(' ');
					}
				}
				System.Console.WriteLine("|");
				for (int j = 0; j < Config.Columns; j++)
					System.Console.Write("+--------");
				System.Console.WriteLine("+");
			}
			System.Console.WriteLine();
			System.Console.WriteLine("Allowed keys (Up, Down, Left, Right, Reset(R), Quit(Q))");
		}
	}
}
