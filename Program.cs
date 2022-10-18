using System;
using System.Collections.Generic;

namespace TicTacToe_006
{
    enum ApprovedSymbols{ o, x, m, n}
    class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new Player(ApprovedSymbols.x.ToString(), "PlayerOne");
            var playerTwo = new ComputerPlayer(ApprovedSymbols.o.ToString(), "PlayerTwo");
            var board = new Board();
            var players = new List<IPlayer> {playerOne, playerTwo};

            while (!board.IsBoardFull())
            {
                foreach (var player in players)
                {
                    player.GetPlayerMove(board);
                    if (board.HasWon(player.Symbol))
                    {
                        Console.WriteLine("\n" + player.PlayerName + " has won the game" + "\n" + "\n" + board.Display());
                        Environment.Exit(0);
                    }
                    board.CheckIfBoardIsFull(board);
                }
            }
        }
    }
}