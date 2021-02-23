namespace tictactoe {
    public class ArrayBoard: IBoard {
        private Field[,] board = new Field[3,3];

        public ArrayBoard() {}
        public ArrayBoard(Field [,] customBoard) {
            if (customBoard.Length != 3 && customBoard.GetLength(0) != 3) {
                throw new System.ArgumentException("need a 3x3 array");
            }
            board = customBoard;
        }

        public Field this[int x, int y] {
            get => board[y, x];
            set => board[y, x] = value;
        }
    }
}