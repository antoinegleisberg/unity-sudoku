using NUnit.Framework;
using antoinegleisberg.SudokuGame.SudokuGrid;
using System.Collections.Generic;

namespace antoinegleisberg.SudokuGame.Editor.Tests
{
    public class SudokuUtilitiesTests
    {
        [Test]
        public void RowColBlockIsValidTest_EmptyGrid_Size9()
        {
            int[,] grid =
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            for (int i = 0; i < 9; i++)
            {
                Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3));
            }
        }

        [Test]
        public void RowColBlockIsValidTest_Size9()
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

            for (int i = 0; i < 9; i++)
            {
                Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3));
            }
        }

        [Test]
        public void RowColBlockIsValidTest_TestInvalidDetection_Size9()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 2, 0, 0, 0 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 3, 0, 0, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 8 },
                {0, 0, 0, 0, 0, 0, 0, 4, 0 },
            };

            for (int i = 0; i < 9; i++)
            {
                if (i != 0)
                {
                    Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                }
                Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                if (i != 8)
                {
                    Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 3));
                }
            }
            Assert.IsFalse(SudokuUtilities.RowIsValid(grid, 0));
            Assert.IsFalse(SudokuUtilities.BlockIsValid(grid, 2, 2, 3));
        }

        [Test]
        public void RowColBlockIsValidTest_EmptyGrid_Size6()
        {
            int[,] grid =
            {
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 }
            };

            for (int i = 0; i < 6; i++)
            {
                Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 2, i % 2, 3));
                Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 3, i % 3, 2));
            }
        }

        [Test]
        public void RowColBlockIsValidTest_Size6()
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

            for (int i = 0; i < 6; i++)
            {
                Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 2, i % 2, 3));
            }
        }

        [Test]
        public void RowColBlockIsValidTest_TestInvalidDetection_Size6()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 0, 0, 0 },
                {5, 0, 0, 0, 3, 0 },
                {0, 6, 0, 3, 2, 0 },
                {0, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };

            for (int i = 0; i < 6; i++)
            {
                Assert.IsTrue(SudokuUtilities.RowIsValid(grid, i));
                
                if (i != 3)
                {
                    Assert.IsTrue(SudokuUtilities.ColumnIsValid(grid, i));
                }
                if (i != 3)
                {
                    Assert.IsTrue(SudokuUtilities.BlockIsValid(grid, i / 2, i % 2, 3));
                }
            }
            Assert.IsFalse(SudokuUtilities.ColumnIsValid(grid, 3));
            Assert.IsFalse(SudokuUtilities.BlockIsValid(grid, 1, 1, 3));
        }

        [Test]
        public void PossibleNumbersTest_Size9()
        {
            int[,] grid =
            {
                {0, 2, 0, 0, 0, 2, 0, 0, 7 },
                {0, 0, 0, 6, 0, 0, 0, 0, 3 },
                {0, 7, 4, 0, 8, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 3, 0, 4, 2 },
                {0, 8, 0, 0, 4, 0, 0, 1, 0 },
                {6, 0, 0, 5, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 1, 0, 7, 8, 0 },
                {5, 0, 0, 0, 0, 9, 0, 0, 8 },
                {0, 0, 0, 0, 0, 0, 0, 4, 9 },
            };

            List<int> possibles_0_0 = new List<int> { 1, 3, 8, 9 };
            List<int> possibles_4_5 = new List<int> { 6, 7 };
            List<int> possibles_5_8 = new List<int> { };

            Assert.AreEqual(possibles_0_0, SudokuUtilities.PossibleNumbers(grid, 0, 0, 3));
            Assert.AreEqual(possibles_4_5, SudokuUtilities.PossibleNumbers(grid, 4, 5, 3));
            Assert.AreEqual(possibles_5_8, SudokuUtilities.PossibleNumbers(grid, 5, 8, 3));
        }

        [Test]
        public void PossibleNumbersTest_Size6_1()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 0, 0, 0 },
                {5, 1, 0, 0, 3, 0 },
                {0, 6, 0, 3, 2, 0 },
                {4, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };

            List<int> possibles_0_2 = new List<int> { 1, 4 };
            List<int> possibles_1_3 = new List<int> { 1, 2, 4, 6 };
            List<int> possibles_5_5 = new List<int> { 1, 2, 5 };
            List<int> possibles_3_0 = new List<int> { };

            Assert.AreEqual(possibles_0_2, SudokuUtilities.PossibleNumbers(grid, 0, 2, 3));
            Assert.AreEqual(possibles_1_3, SudokuUtilities.PossibleNumbers(grid, 1, 3, 3));
            Assert.AreEqual(possibles_5_5, SudokuUtilities.PossibleNumbers(grid, 5, 5, 3));
            Assert.AreEqual(possibles_3_0, SudokuUtilities.PossibleNumbers(grid, 3, 0, 3));
        }

        [Test]
        public void PossibleNumbersTest_Size6_2()
        {
            int[,] grid =
            {
                {6, 2, 0, 5, 0, 3 },
                {0, 0, 0, 0, 0, 0 },
                {5, 1, 0, 0, 3, 0 },
                {0, 6, 0, 3, 2, 0 },
                {4, 0, 0, 3, 4, 6 },
                {3, 0, 6, 0, 0, 0 }
            };


            List<int> possibles_0_2 = new List<int> { 1, 4 };
            List<int> possibles_1_3 = new List<int> { 1, 2, 4, 6 };
            List<int> possibles_5_5 = new List<int> { 1, 5 };
            List<int> possibles_3_0 = new List<int> { 1 };

            Assert.AreEqual(possibles_0_2, SudokuUtilities.PossibleNumbers(grid, 0, 2, 2));
            Assert.AreEqual(possibles_1_3, SudokuUtilities.PossibleNumbers(grid, 1, 3, 2));
            Assert.AreEqual(possibles_5_5, SudokuUtilities.PossibleNumbers(grid, 5, 5, 2));
            Assert.AreEqual(possibles_3_0, SudokuUtilities.PossibleNumbers(grid, 3, 0, 2));
        }
    }
}
