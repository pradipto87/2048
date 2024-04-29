namespace _2048
{
	public class HumanPlayer : IPlayer
	{
		public HumanPlayer()
		{
		}
		public string GetPlayerType()
		{
			return "Human";
		}
		public Direction GetMove(Game game)
		{
			return Direction.Up;
		}
	}
}

