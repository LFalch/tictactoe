using System;

namespace tictactoe {
    public class Game {
        private IBot botCross, botNaught;
        private ArrayBoard board = new ArrayBoard();
        private bool crossTurn = true;

        public IBoard Board => board;
        public IBot Winner { get; private set; }

        public Game(IBot crosses, IBot naughts) {
            botCross = crosses;
            botNaught = naughts;
        }
        public Game(IBot crosses, IBot naughts, ArrayBoard board) : this(crosses, naughts) {
            this.board = board;
        }

        private Field Line(int i, int j, int x, int y, int a, int b) {
            var f1 = board[i, j];
            var f2 = board[x, y];
            var f3 = board[a, b];

            if (f1 == f2 && f2 == f3)
                if (f1 == Field.Empty || f2 == Field.Empty || f3 == Field.Empty)
                    return Field.Empty;
                else
                    return f1;
            else
                return Field.Empty;
        }

        private static readonly (int, int, int, int, int, int)[] winCons = {
            // Lines
            (0, 0, 0, 1, 0, 2),
            (1, 0, 1, 1, 1, 2),
            (2, 0, 2, 1, 2, 2),
            // Lines
            (0, 0, 1, 0, 2, 0),
            (0, 1, 1, 1, 2, 1),
            (0, 2, 1, 2, 2, 2),
            // Diagonals
            (0, 0, 1, 1, 2, 2),
            (2, 0, 1, 1, 0, 2),
        };

        public bool IsFinished() {
            foreach (var (i, j, x, y, a, b) in winCons) {
                var f = Line(i, j, x, y, a, b);
                switch (f) {
                    case Field.Empty:
                    break;
                    case Field.Cross:
                    Winner = botCross;
                    return true;
                    case Field.Naught:
                    Winner = botNaught;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Plays one turn of the game
        /// </summary>
        /// <returns>
        /// Whether the game is now finished
        /// </returns>
        public bool DoTurn() {
            var curBot = crossTurn ? botCross : botNaught;

            var (i, j) = curBot.MakeMove(Board);
            if (board[i, j] != Field.Empty) throw new System.Exception("Bot tried to play on an occupied field");
            board[i, j] = crossTurn ? Field.Cross : Field.Naught;

            crossTurn = !crossTurn;

            return IsFinished();
        }

        public void PlayUntilFinished() {
            while (!DoTurn()) { }
        }

        public static void DrawBoard(IBoard board) {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    switch (board[i, j]) {
                        case Field.Empty:
                        Console.Write(" _");
                        break;
                        case Field.Cross:
                        Console.Write(" X");
                        break;
                        case Field.Naught:
                        Console.Write(" O");
                        break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
