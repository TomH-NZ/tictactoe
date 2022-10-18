using System;

namespace TicTacToe_006
{
    public class Player : IPlayer
    {
        public string PlayerName { get; }
        public string Symbol { get; }
        public void GetPlayerMove(Board board)
        {
            var move = "";
            while (!board.ValidateMove(move))
            {
                Console.WriteLine(board.Display());
                move = EnterMove(PlayerName);
                if (!board.ValidateMove(move)) continue;
                board.AddMove(move, Symbol);
                Console.WriteLine(board.Display());
                break;
            }
        }
        public Player(string symbol, string playerName)
        {
            PlayerName = playerName;
            Symbol = symbol;
        }

        private static string EnterMove(string playerName)
        {
            Console.WriteLine(playerName + ", please enter a move or press q to quit: ");
            Console.WriteLine();
            var playerMove = Console.ReadLine();
            return playerMove;
        }
    }
}