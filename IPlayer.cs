namespace TicTacToe_006
{
    public interface IPlayer
    {
        string PlayerName { get; }
        string Symbol { get; }
        void GetPlayerMove(Board board);
    }
}