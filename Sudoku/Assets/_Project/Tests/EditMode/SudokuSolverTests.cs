using antoinegleisberg.SudokuGame.SudokuGrid;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.Editor.Tests
{
    public class SudokuSolverTests
    {
        [Test]
        public void TestSudokuSolver_Size9_1()
        {
            int[,] grid =
            {
                {0, 0, 0, 2, 6, 0, 7, 0, 1 },
                {6, 8, 0, 0, 7, 0, 0, 9, 0 },
                {1, 9, 0, 0, 0, 4, 5, 0, 0 },
                {8, 2, 0, 1, 0, 0, 0, 4, 0 },
                {0, 0, 4, 6, 0, 2, 9, 0, 0 },
                {0, 5, 0, 0, 0, 3, 0, 2, 8 },
                {0, 0, 9, 3, 0, 0, 0, 7, 4 },
                {0, 4, 0, 0, 5, 0, 0, 3, 6 },
                {7, 0, 3, 0, 1, 8, 0, 0, 0 },
            };

            Assert.IsTrue(SudokuSolver.Solve(grid, 3));
        }

        [Test]
        public void TestSudokuSolver_Size9_2()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 7, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 4, 0 },
            };

            Assert.IsTrue(SudokuSolver.Solve(grid, 3));
        }

        [Test]
        public void TestSudokuSolver_Size9_3()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 7, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 1, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 0 },
                {7, 3, 0, 0, 0, 0, 0, 0, 0 },
            };

            Assert.IsTrue(SudokuSolver.Solve(grid, 3));
        }

        [Test]
        public void TestSudokuSolver_Size6_1()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 0, 0, 0 },
                {5, 0, 0, 0, 3, 0 },
                {0, 6, 0, 0, 2, 0 },
                {0, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };

            Assert.IsTrue(SudokuSolver.Solve(grid, 3));
        }

        [Test]
        public void TestSudokuSolver_Size6_2()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 6, 0, 0 },
                {5, 0, 0, 0, 3, 0 },
                {0, 6, 0, 0, 2, 0 },
                {0, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };

            Assert.IsFalse(SudokuSolver.Solve(grid, 3));
        }

        [Test]
        public void TestSolutionCounter_Size9_1()
        {
            int[,] grid =
            {
                {0, 0, 0, 2, 6, 0, 7, 0, 1 },
                {6, 8, 0, 0, 7, 0, 0, 9, 0 },
                {1, 9, 0, 0, 0, 4, 5, 0, 0 },
                {8, 2, 0, 1, 0, 0, 0, 4, 0 },
                {0, 0, 4, 6, 0, 2, 9, 0, 0 },
                {0, 5, 0, 0, 0, 3, 0, 2, 8 },
                {0, 0, 9, 3, 0, 0, 0, 7, 4 },
                {0, 4, 0, 0, 5, 0, 0, 3, 6 },
                {7, 0, 3, 0, 1, 8, 0, 0, 0 },
            };

            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 1);
        }

        [Test]
        public void TestSolutionCounter_Size9_2()
        {
            int[,] grid =
            {
                {0, 0, 3, 4, 5, 6, 7, 8, 9 },
                {7, 8, 9, 0, 0, 3, 4, 5, 6 },
                {4, 5, 6, 7, 8, 9, 0, 0, 3 },
                {3, 0, 0, 8, 4, 5, 9, 6, 7 },
                {6, 9, 7, 3, 0, 0, 8, 4, 5 },
                {8, 4, 5, 6, 9, 7, 3, 0, 0 },
                {0, 3, 0, 5, 7, 4, 6, 9, 8 },
                {9, 6, 8, 0, 3, 0, 5, 7, 4 },
                {5, 7, 4, 9, 6, 8, 0, 3, 0 },
            };

            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 8);
        }
        
        [Test]
        public void TestSolutionCounter_Size9_3()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 7, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 4, 0 },
            };

            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 1);
        }

        [Test]
        public void TestSolutionCounter_Size9_4()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 7, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 1, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 0 },
                {7, 3, 0, 0, 0, 0, 0, 0, 0 },
            };

            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 5);
        }

        [Test]
        public void TestSolutionCounter_Size6_1()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 0, 0, 0 },
                {5, 0, 0, 0, 3, 0 },
                {0, 6, 0, 0, 2, 0 },
                {0, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };
            
            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 1);
        }

        [Test]
        public void TestSolutionCounter_Size6_2()
        {
            int[,] grid =
            {
                {1, 3, 0, 4, 0, 0 },
                {0, 0, 6, 5, 0, 0 },
                {0, 5, 1, 0, 0, 0 },
                {0, 0, 2, 0, 0, 0 },
                {0, 0, 0, 6, 4, 0 },
                {0, 1, 0, 0, 0, 0 }
            };

            Assert.AreEqual(SudokuSolver.CountSolutions(grid, 3), 4);
        }
    }
}
