using NUnit.Framework;
using antoinegleisberg.SudokuGame.SudokuGrid;

namespace antoinegleisberg.SudokuGame.Editor.Tests
{
    public class GridGenerationTests
    {
        [Test]
        public void TestEmptyGridGeneration()
        {
            int[,] emptyGrid = new int[9, 9];
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    emptyGrid[i, j] = 0;
                }
            }

            int[,] generatedGrid = SudokuGenerator.GenerateEmpty();

            Assert.AreEqual(generatedGrid, emptyGrid);
        }

        [Test]
        public void TestSudokuSolver_1()
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
        public void TestSolutionCounter_1()
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

            Assert.IsTrue(SudokuSolver.CountSolutions(grid, 9) == 1);
        }

        [Test]
        public void TestSudokuSolver_2()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 0, 0, 0, 0 },
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
        public void TestSolutionCounter_2()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 4, 0 },
            };

            Assert.IsTrue(SudokuSolver.CountSolutions(grid, 9) == 1);
        }


        [Test]
        public void TestSudokuSolver_3()
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
        public void TestSolutionCounter_3()
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

            Assert.IsTrue(SudokuSolver.CountSolutions(grid, 9) == 5);
        }
    }
}
