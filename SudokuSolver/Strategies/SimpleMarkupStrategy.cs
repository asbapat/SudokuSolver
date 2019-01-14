using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class SimpleMarkupStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkupStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0 || board[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(board, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(board, row, col);
                        board[row, col] = GetPossibilityIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                    }
                }
            }

            return board;
        }

        private int GetPossibilitiesInRowAndCol(int[,] board, int row, int col)
        {
            int[] possibleValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for(int c = 0; c < 9; c++)
            {
                if (IsValidValue(board[row, c]))
                {
                    possibleValues[board[row, c] - 1] = 0;
                }
            }

            for(int r = 0; r < 9; r++)
            {
                if (IsValidValue(board[r, col]))
                {
                    possibleValues[board[r, col] - 1] = 0;
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibleValues.Select(p => p).Where(p => p!=0)));
        }


        private int GetPossibilitiesInBlock(int[,] board, int row, int col)
        {
            int[] possibleValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(row, col);
            for(int r = sudokuMap.StartRow; r <= sudokuMap.StartRow + 2; r++)
            {
                for(int c = sudokuMap.StartCol; c<= sudokuMap.StartCol + 2; c++)
                {
                    if (IsValidValue(board[r, c]))
                        possibleValues[board[r, c] - 1] = 0;
                }
            }

            return Convert.ToInt32(String.Join(string.Empty, possibleValues.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityIntersection(int possibilitiesInRowAndCol, int possibilitiesInBlock)
        {
            var possibilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
            var possibilitiesInBlockCharArray = possibilitiesInBlock.ToString().ToCharArray();
            var possibilitySubset = possibilitiesInRowAndColCharArray.Intersect(possibilitiesInBlockCharArray);

            return Convert.ToInt32(string.Join(string.Empty, possibilitySubset));
        }


        private bool IsValidValue(int cellValue)
        {
            return (cellValue != 0 && cellValue.ToString().Length < 2);
                
        }
    }
}
