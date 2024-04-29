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
