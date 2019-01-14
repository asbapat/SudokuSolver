using SudokuSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuMapper
    {
        public SudokuMap Find (int givenRow, int givenCol)
        {
            SudokuMap sudokuMap = new SudokuMap();

            if((givenRow >=0 && givenRow < 3) && (givenCol>=0 && givenCol < 3))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 0;
            }
            else if ((givenRow >= 0 && givenRow < 3) && (givenCol >= 3 && givenCol < 6))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 3;
            }
            else if ((givenRow >= 0 && givenRow < 3) && (givenCol >= 6 && givenCol < 9))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 6;
            }
            else if ((givenRow >= 3 && givenRow < 6) && (givenCol >= 0 && givenCol < 3))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 0;
            }
            else if ((givenRow >= 3 && givenRow < 6) && (givenCol >= 3 && givenCol < 6))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 3;
            }
            else if ((givenRow >= 3 && givenRow < 6) && (givenCol >= 6 && givenCol < 9))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 6;
            }
            else if ((givenRow >= 6 && givenRow < 9) && (givenCol >= 0 && givenCol < 3))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 0;
            }
            else if ((givenRow >= 6 && givenRow < 9) && (givenCol >= 3 && givenCol < 6))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 3;
            }
            else if ((givenRow >= 6 && givenRow < 9) && (givenCol >= 6 && givenCol < 9))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 6;
            }
            return sudokuMap;
        }
    }
}
