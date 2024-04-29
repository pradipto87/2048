namespace _2048
{
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}
	public class Game
	{
		private int score;
		private int moveCnt;
		private int[,] board;
		private Random random;
		public Game()
		{
			score = 0;
			moveCnt = 0;
			board = new int[4, 4];
			random = new Random();
			AddTile();
			AddTile();
		}
		public bool IsOver()
		{
			for(int i = 0; i < 4; ++i)
				for(int j = 0; j < 4; ++j)
					if (board[i, j] == 0)
						return false;
			return true;
		}
		private void AddTile()
		{
			List<(int, int)> emptyTiles = new List<(int, int)>();
			for (int i = 0; i < 4; ++i)
				for (int j = 0; j < 4; ++j)
					if (board[i, j] == 0)
						emptyTiles.Add((i, j));
			if (emptyTiles.Count > 0)
			{
				(int, int) tile = emptyTiles[random.Next(emptyTiles.Count)];
				board[tile.Item1, tile.Item2] = random.Next(10) < 9 ? 1 : 2;
			}
		}
		public void Update(Direction move)
		{
			//move
			//add new tile
		}
	}
}
