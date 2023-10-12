using NUnit.Framework;
using antoinegleisberg.SudokuGame.SudokuGrid;

namespace antoinegleisberg.SudokuGame.Editor.Tests
{
    public class SudokuGeneratorTests
    {
        [Test]
        public void GenerateEmptyTest_Size9()
        {
            int[,] emptyGrid = new int[9, 9];
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    emptyGrid[i, j] = 0;
                }
            }

            int[,] generatedGrid = SudokuGenerator.GenerateEmpty(9);

            Assert.AreEqual(generatedGrid, emptyGrid);
        }

        [Test]
        public void GenerateEmptyTest_Size6()
        {
            int[,] emptyGrid = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    emptyGrid[i, j] = 0;
                }
            }

            int[,] generatedGrid = SudokuGenerator.GenerateEmpty(6);

            Assert.AreEqual(generatedGrid, emptyGrid);
        }

        [Test]
        public void GenerateFullTest_IsFull_Size9()
        {
            int[,] grid = SudokuGenerator.GenerateFull(9, 3);

            bool foundZero = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        foundZero = true;
                    }
                }
            }

            Assert.IsFalse(foundZero);
        }


        [Test]
        public void GenerateFullTest_IsFull_Size6()
        {
            int[,] grid = SudokuGenerator.GenerateFull(6, 3);

            bool foundZero = false;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        foundZero = true;
                    }
                }
            }

            Assert.IsFalse(foundZero);
        }

        [Test]
        public void GenerateFullTest_IsValid_Size9()
        {
            int[,] grid = SudokuGenerator.GenerateFull(9, 3);

            bool isValid = true;

            for (int i = 0; i < 9; i++)
            {
                isValid = isValid && SudokuUtilities.RowIsValid(grid, i);
                isValid = isValid && SudokuUtilities.ColumnIsValid(grid, i);
                isValid = isValid && SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3);
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void GenerateFullTest_IsValid_Size6()
        {
            int[,] grid = SudokuGenerator.GenerateFull(6, 2);

            bool isValid = true;

            for (int i = 0; i < 6; i++)
            {
                isValid = isValid && SudokuUtilities.RowIsValid(grid, i);
                isValid = isValid && SudokuUtilities.ColumnIsValid(grid, i);
                isValid = isValid && SudokuUtilities.BlockIsValid(grid, i % 2, i / 2, 2);
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountMissingDigits_Size9_MissingDigits30()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 30);

            int counter = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(counter, 30);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountMissingDigits_Size6_MissingDigits15()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(6, 3, 15);

            int counter = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(counter, 15);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountMissingDigits_Size9_MissingDigits0()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 0);

            int counter = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(counter, 0);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_IsValid_Size9_MissingDigits30()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 30);

            bool isValid = true;

            for (int i = 0; i < 9; i++)
            {
                isValid = isValid && SudokuUtilities.RowIsValid(grid, i);
                isValid = isValid && SudokuUtilities.ColumnIsValid(grid, i);
                isValid = isValid && SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3);
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_IsValid_Size6_MissingDigits15()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(6, 3, 15);

            bool isValid = true;

            for (int i = 0; i < 6; i++)
            {
                isValid = isValid && SudokuUtilities.RowIsValid(grid, i);
                isValid = isValid && SudokuUtilities.ColumnIsValid(grid, i);
                isValid = isValid && SudokuUtilities.BlockIsValid(grid, i / 2, i % 2, 3);
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_IsValid_Size9_MissingDigits0()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 0);

            bool isValid = true;

            for (int i = 0; i < 9; i++)
            {
                isValid = isValid && SudokuUtilities.RowIsValid(grid, i);
                isValid = isValid && SudokuUtilities.ColumnIsValid(grid, i);
                isValid = isValid && SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3);
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountSolutions_Size9_MissingDigits30()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 30);

            int numberOfSolutions = SudokuSolver.CountSolutions(grid, 3);

            Assert.AreEqual(numberOfSolutions, 1);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountSolutions_Size6_MissingDigits15()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(6, 3, 15);

            int numberOfSolutions = SudokuSolver.CountSolutions(grid, 3);

            Assert.AreEqual(numberOfSolutions, 1);
        }

        [Test]
        public void GenerateSudokuWithUniqueSolutionTest_CountSolutions_Size9_MissingDigits0()
        {
            int[,] grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(9, 3, 0);

            int numberOfSolutions = SudokuSolver.CountSolutions(grid, 3);

            Assert.AreEqual(numberOfSolutions, 1);
        }
    }
}
