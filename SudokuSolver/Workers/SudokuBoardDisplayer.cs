using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuBoardDisplayer
    {
        public void Display(string title, int[,] sudokuBoard)
        {
            if (!title.Equals(string.Empty))
                Console.WriteLine("{0} {1}", title, Environment.NewLine);

            for(int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                Console.Write("|");
                for(int j=0; j < sudokuBoard.GetLength(1); j++)
                {
                    Console.Write("{0} {1}", sudokuBoard[i, j], "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
