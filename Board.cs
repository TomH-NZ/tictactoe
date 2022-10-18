using System;

namespace TicTacToe_006
{
    public class Board
    {
        private readonly string[] _moves = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        public bool ValidateMove(string playerMove)
        {
            if (playerMove == "q")
            {
                Environment.Exit(0);
            }
            var errorMove = int.TryParse(playerMove, out int moveLocation);
            if (!errorMove)
            {
                return false;
            }
            if (moveLocation is < 1 or > 9)
            {
                return false;
            }
            return _moves[moveLocation -1] != Convert.ToString(ApprovedSymbols.X) && _moves[moveLocation -1] != Convert.ToString(ApprovedSymbols.O);
        }
        public string Display()
        {
            var board = _moves[0] + "|" + _moves[1] + "|" + _moves[2] + "\n" + _moves[3] + "|" + _moves[4] + "|" + _moves[5] + "\n" + _moves[6] + "|" + _moves[7] + "|" + _moves[8];
            return board;
        }
        public void AddMove(string playerMove, string playerSymbol)
        {
            var moveLocation = Convert.ToInt32(playerMove);
            _moves[moveLocation - 1] = playerSymbol;
        }
        public bool IsBoardFull()
        {
            foreach (var symbol in _moves)
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
            if ((_moves[0] == playerSymbol && _moves[1] == playerSymbol && _moves[2] == playerSymbol) ||
                (_moves[3] == playerSymbol && _moves[4] == playerSymbol && _moves[5] == playerSymbol) ||
                (_moves[6] == playerSymbol && _moves[7] == playerSymbol && _moves[8] == playerSymbol))
            {
                return true;
            }
            if ((_moves[0] == playerSymbol && _moves[3] == playerSymbol && _moves[6] == playerSymbol) || 
                (_moves[1] == playerSymbol && _moves[4] == playerSymbol && _moves[7] == playerSymbol) || 
                (_moves[2] == playerSymbol && _moves[5] == playerSymbol && _moves[8] == playerSymbol))
            {
                return true;
            }
            return (_moves[0] == playerSymbol && _moves[4] == playerSymbol && _moves[8] == playerSymbol) || (_moves[2] == playerSymbol && _moves[4] == playerSymbol && _moves[6] == playerSymbol);
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