using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class NakedPairsStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairsStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    EliminateNakedPairsFromRow(board, i, j);
                    EliminateNakedPairFromCol(board, i, j);
                    EliminateNakedPairFromBlock(board, i, j);
                }
            }
            return board;
        }

        private void EliminateNakedPairsFromRow(int[,] board, int row, int col)
        {
            if (!HasNakedPairInRow(board, row, col)) return;

            for(int c=0; c < board.GetLength(1); c++)
            {
                if(board[row,c] != board[row,col] && board[row,c].ToString().Length > 1)
                {
                    EliminateNakedPair(board, board[row, col], row, c);
                }
            }
        }

        private void EliminateNakedPair(int[,] board, int valuesToEliminate, int row, int c)
        {
            //var valuesToEliminateArray = valuesToEliminate.ToString().ToCharArray();
            //foreach(var value in valuesToEliminateArray)
            //{
            //    board[row, c] = Convert.ToInt32(board[row, c].ToString().Replace(value.ToString(), string.Empty));
            //}

            board[row, c] = Convert.ToInt32(board[row, c].ToString().Replace(valuesToEliminate.ToString(), string.Empty));
        }

        private void EliminateNakedPairFromCol(int[,] board, int row, int col)
        {
            if (!HasNakedPairInCol(board, row, col)) return;

            for (int r = 0; r < board.GetLength(0); r++)
            {
                if (board[r, col] != board[row, col] && board[r, col].ToString().Length > 1)
                {
                    EliminateNakedPair(board, board[row, col], r, col);
                }
            }
        }

        private bool HasNakedPairInCol(int[,] board, int row, int col)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                if (r != row && IsNakedpair(board[r, col], board[row, col]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairFromBlock(int[,] board, int row, int col)
        {
            if (!HasNakedPairInBlock(board, row, col)) return;

            var sudokuMap = _sudokuMapper.Find(row, col);

            for (int r = sudokuMap.StartRow; r <= sudokuMap.StartRow + 2; r++)
            {
                for (int c = sudokuMap.StartCol; c <= sudokuMap.StartCol + 2; c++)
                {
                    if (board[r, c].ToString().Length > 1 && board[r, c] != board[row, col])
                        EliminateNakedPair(board, board[row, col], r, c);
                }
            }
        }

        private bool HasNakedPairInBlock(int[,] board, int row, int col)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if(r!=row && c != col)
                    {
                        var elementInSameBlock = _sudokuMapper.Find(row, col).StartRow == _sudokuMapper.Find(r, c).StartRow &&
                                                _sudokuMapper.Find(row, col).StartCol == _sudokuMapper.Find(r, c).StartCol;

                        if (elementInSameBlock && IsNakedpair(board[row, col], board[r, c]))
                            return true;
                    }
                }
            }
            return false;
        }

        private bool HasNakedPairInRow(int[,] board, int row, int col)
        {
            for(int c = 0; c < board.GetLength(1); c++)
            {
                if (c != col && IsNakedpair(board[row, c], board[row, col]))
                    return true;
            }
            return false;
        }

        private bool IsNakedpair(int firstPair, int secondPair)
        {
            return firstPair.ToString().Length == 2 && firstPair == secondPair;
        }
    }
}
