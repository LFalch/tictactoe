namespace tictactoe {
    public class GameTest {
        private class BrokenBot : IBot {
            public BrokenBot() {}

            public (int, int) MakeMove(IBoard board) {
                throw new System.NotImplementedException();
            }
        }
        private readonly BrokenBot bot = new BrokenBot();
        private const Field x = Field.Cross;
        private const Field o = Field.Naught;
        private const Field e = Field.Empty;

        public GameTest() {}

        public bool FinishedStates() {
            // X
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{x, x, x}, {e, e, e}, {e, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, e}, {x, x, x}, {e, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, e}, {e, e, e}, {x, x, x}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, x}, {e, e, x}, {e, e, x}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, x, e}, {e, x, e}, {e, x, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{x, e, e}, {x, e, e}, {x, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{x, e, e}, {e, x, e}, {e, e, x}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, x}, {e, x, e}, {x, e, e}})).IsFinished())
                return false;
            // O
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{o, o, o}, {e, e, e}, {e, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, e}, {o, o, o}, {e, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, e}, {e, e, e}, {o, o, o}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, o}, {e, e, o}, {e, e, o}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, o, e}, {e, o, e}, {e, o, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{o, e, e}, {o, e, e}, {o, e, e}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{o, e, e}, {e, o, e}, {e, e, o}})).IsFinished())
                return false;
            if (!new Game(bot, bot, new ArrayBoard(new Field[,] {{e, e, o}, {e, o, e}, {o, e, e}})).IsFinished())
                return false;
            return true;
        }
    }
}