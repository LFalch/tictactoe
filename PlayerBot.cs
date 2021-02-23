using System;

namespace tictactoe {
    public class PlayerBot : IBot {
        public PlayerBot() {}

        private static (int, int)? ValidateMove(IBoard board, string move) {
            var args = move.Split(' ');
            int i = int.Parse(args[0]) - 1;
            int j = int.Parse(args[1]) - 1;

            if (0 <= i && i < 3 && 0 <= j && j < 3) {
                if(board[i, j] == Field.Empty) {
                    return (i, j);
                }
            }
            return null;
        }

        public (int, int) MakeMove(IBoard board) {
            Game.DrawBoard(board);


            Console.WriteLine();
            (int, int)? move = null;

            while (move == null) {
                Console.Write("Move: ");
                move = ValidateMove(board, Console.ReadLine().Trim());
            }

            return ((int, int)) move;
        }
    }
}
