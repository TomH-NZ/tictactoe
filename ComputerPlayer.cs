using System;

namespace TicTacToe_006
{
    public class ComputerPlayer : IPlayer
    {
        public string PlayerName { get; }
        public string Symbol { get; }
        public void GetPlayerMove(Board board)
        {
            Random randomMove = new Random();
            Console.WriteLine("press a button to make the PC move");
            Console.ReadLine();
            var move = "";
            while (!board.ValidateMove(move))
            {
                move = Convert.ToString(randomMove.Next(0, 8));
                if (!board.ValidateMove(move)) continue;
                board.AddMove(move, Symbol);
                Console.WriteLine("The PC moved at grid " + move);
                break;
            }
        }
        public ComputerPlayer(string playerName, string symbol)
        {
            PlayerName = playerName;
            Symbol = symbol;
        }
    }
}