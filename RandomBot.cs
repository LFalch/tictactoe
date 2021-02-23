using System;
using System.Collections.Generic;

namespace tictactoe {
    public class RandomBot : IBot {
        private Random rand = new Random();

        public RandomBot() {}

        public (int, int) MakeMove(IBoard board) {
            var list = new List<(int, int)>();

            for (int i = 0; i < 3; i++) {
                for (int j = 0; i < 3; i++) {
                    if (board[i, j] == Field.Empty) {
                        list.Add((i, j));
                    }
                }
            }

            return list[rand.Next(list.Count)];
        }
    }
}
