using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuFileReader
    {
        public int[,] ReadSudokuFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudokuBoardRows = File.ReadAllLines(filename);
                int row = 0;
                foreach(var sudokuRow in sudokuBoardRows)
                {
                    string[] rowElements = sudokuRow.Split('|').Skip(1).Take(9).ToArray();
                    int col = 0;
                    foreach(var rowElement in rowElements)
                    {
                        int element = rowElement.Equals(" ") ? 0 : Convert.ToInt16(rowElement);
                        sudokuBoard[row,col] = element;
                        col++;
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error in reading the Sudoku File" + ex.Message);
            }

            return sudokuBoard;
        }
    }
}
