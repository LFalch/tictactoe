namespace tictactoe {
    public interface IBot {
        (int, int) MakeMove(IBoard board);
    }
}
