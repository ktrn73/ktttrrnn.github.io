using System;
using System.Collections.Generic;

namespace Puzzle15Game
{
    public class GameLogic
    {
        public int[,] Board { get; private set; }
        public int EmptyRow { get; private set; }
        public int EmptyCol { get; private set; }
        public int Size { get; } = 4;

        public GameLogic()
        {
            Board = new int[Size, Size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int value = 1;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    Board[i, j] = value++;
                }
            Board[Size - 1, Size - 1] = 0;
            EmptyRow = Size - 1;
            EmptyCol = Size - 1;
        }

        public void Shuffle(int moves = 300)
        {
            Random rand = new Random();
            for (int step = 0; step < moves; step++)
            {
                var possibleMoves = GetPossibleMoves();
                var move = possibleMoves[rand.Next(possibleMoves.Count)];
                Move(move.Item1, move.Item2);
            }
        }

        private List<(int, int)> GetPossibleMoves()
        {
            var moves = new List<(int, int)>();
            if (EmptyRow > 0) moves.Add((EmptyRow - 1, EmptyCol));
            if (EmptyRow < Size - 1) moves.Add((EmptyRow + 1, EmptyCol));
            if (EmptyCol > 0) moves.Add((EmptyRow, EmptyCol - 1));
            if (EmptyCol < Size - 1) moves.Add((EmptyRow, EmptyCol + 1));
            return moves;
        }

        public bool Move(int row, int col)
        {
            if ((Math.Abs(row - EmptyRow) + Math.Abs(col - EmptyCol)) != 1)
                return false;

            Board[EmptyRow, EmptyCol] = Board[row, col];
            Board[row, col] = 0;
            EmptyRow = row;
            EmptyCol = col;
            return true;
        }

        public bool IsSolved()
        {
            int expected = 1;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (i == Size - 1 && j == Size - 1)
                        return Board[i, j] == 0;
                    if (Board[i, j] != expected)
                        return false;
                    expected++;
                }
            return true;
        }

        public int GetNumberAt(int row, int col) => Board[row, col];
    }
}
