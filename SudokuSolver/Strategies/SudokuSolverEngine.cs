using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuBoardStateManager sudokuBoardStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] board)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>()
            {
                new SimpleMarkupStrategy(_sudokuMapper),
                new NakedPairsStrategy(_sudokuMapper)
            };

            string currentState = _sudokuBoardStateManager.GenerateState(board);
            string nextState = _sudokuBoardStateManager.GenerateState(strategies.First().Solve(board));

            while(!_sudokuBoardStateManager.IsSolved(board) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var strategy in strategies)
                    nextState = _sudokuBoardStateManager.GenerateState(strategy.Solve(board));
            }

            return _sudokuBoardStateManager.IsSolved(board);
        }
    }
}
