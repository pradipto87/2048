namespace _2048
{
    public interface IPlayer
    {
        string GetPlayerType();
        Direction GetMove(Game game);
    }
}
