using System;

namespace TicTacToe_006
{
    public class Board
    {
        private string[] moves = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        public bool ValidateMove(string playerMove)
        {
            if (playerMove == "q")
            {
                Environment.Exit(0);
            }
            bool errorMove = int.TryParse(playerMove, out int moveLocation);
            if (!errorMove)
            {
                return false;
            }
            if (moveLocation <1 || moveLocation > 9)
            {
                return false;
            }
            if (moves[moveLocation -1] == Convert.ToString(ApprovedSymbols.X) || moves[moveLocation -1] == Convert.ToString(ApprovedSymbols.O))
            {
                return false;
            }
            return true;
        }
        public string Display()
        {
            var board = moves[0] + "|" + moves[1] + "|" + moves[2] + "\n" + moves[3] + "|" + moves[4] + "|" + moves[5] + "\n" + moves[6] + "|" + moves[7] + "|" + moves[8];
            return board;
        }
        public void AddMove(string playerMove, string playerSymbol)
        {
            var moveLocation = Convert.ToInt32(playerMove);
            moves[moveLocation - 1] = playerSymbol;
        }
        public bool IsBoardFull()
        {
            foreach (var symbol in moves)
            {
                if (symbol != "x" && symbol != "o")
                {
                    return false;
                }
            }
            return true;
        }
        public bool HasWon(string playerSymbol)
        {
            if ((moves[0] == playerSymbol && moves[1] == playerSymbol && moves[2] == playerSymbol) ||
                (moves[3] == playerSymbol && moves[4] == playerSymbol && moves[5] == playerSymbol) ||
                (moves[6] == playerSymbol && moves[7] == playerSymbol && moves[8] == playerSymbol))
            {
                return true;
            }
            if ((moves[0] == playerSymbol && moves[3] == playerSymbol && moves[6] == playerSymbol) || 
                (moves[1] == playerSymbol && moves[4] == playerSymbol && moves[7] == playerSymbol) || 
                (moves[2] == playerSymbol && moves[5] == playerSymbol && moves[8] == playerSymbol))
            {
                return true;
            }
            if ((moves[0] == playerSymbol && moves[4] == playerSymbol && moves[8] == playerSymbol) || (moves[2] == playerSymbol && moves[4] == playerSymbol && moves[6] == playerSymbol))
            {
                return true;
            }

            return false;
        }
        public void CheckIfBoardIsFull(Board board)
        {
            if (!IsBoardFull()) return;
            Console.WriteLine("This game is a draw");
            Console.WriteLine(board.Display());
            Environment.Exit(0);
        }
    }
}