namespace _2048
{
	public interface IPlayer
	{
		string PlayerType { get; }
		Direction GetMove(Game game);
	}
}
