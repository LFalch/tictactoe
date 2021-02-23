using System;

namespace tictactoe {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Finished states test: {0}", new GameTest().FinishedStates());

            PlayGame(new PlayerBot(), new RandomBot());
        }

        static void PlayGame(IBot crossBot, IBot naughtBot) {
            var game = new Game(crossBot, naughtBot);

            game.PlayUntilFinished();

            Console.WriteLine("A winner was found: {0}!", game.Winner);
            Game.DrawBoard(game.Board);
        }
    }
}
