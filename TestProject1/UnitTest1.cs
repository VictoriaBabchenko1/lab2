using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1;
using System;

namespace TestProject1
{
    [TestClass]
    public class MyMatrixTests
    {
        [TestMethod]
        public void CopyConstructorTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            MyMatrix matrix1 = new MyMatrix(matrix);

            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix1.Width; j++)
                {
                    Assert.AreEqual(matrix1[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void JaggedArrayConstructorTest()
        {
            double[][] elements = new double[3][];
            elements[0] = new double[] { 1, 2, 3, 4 };
            elements[1] = new double[] { 5, 6, 7, 8 };
            elements[2] = new double[] { 9, 0, 1, 2 };

            MyMatrix matrix = new MyMatrix(elements);

            double[,] correct_matrix_elements = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 0, 1, 2 } };

            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Assert.AreEqual(correct_matrix_elements[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The matrix must be rectangular")]
        public void JaggedArrayConstructorExceptionTest()
        {
            double[][] elements = new double[3][];
            elements[0] = new double[] { 1, 2, 3, 4 };
            elements[1] = new double[] { 5, 6 };
            elements[2] = new double[] { 9, 0, 1 };

            new MyMatrix(elements);
        }

        [TestMethod]
        public void StringArrayConstructorTest()
        {
            string[] elements = { "2 3  1", "3 2    2", "4 3 1 " };

            MyMatrix matrix = new MyMatrix(elements);

            double[,] correct_matrix_elements = { { 2, 3, 1 }, { 3, 2, 2 }, { 4, 3, 1 } };

            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Assert.AreEqual(correct_matrix_elements[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The matrix must be rectangular and contain only numerical values")]
        public void StringArrayConstructorExceptionTest()
        {
            string[] elements = { "2 3  1", "3 2   ", "4 3 1 " };

            new MyMatrix(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The matrix must be rectangular and contain only numerical values")]
        public void StringArrayConstructorExceptionWithLettersTest()
        {

            string[] elements = { "2 ò  1", "3  w 4 ", "4 3 1 " };

            new MyMatrix(elements);
        }

        [TestMethod]
        public void StringConstructorTest()
        {
            string elements = "3   1  \n4   1\n5 1";
            MyMatrix matrix = new MyMatrix(elements);

            double[,] correct_matrix_elements = { { 3, 1 }, { 4, 1 }, { 5, 1 } };

            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Assert.AreEqual(correct_matrix_elements[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The matrix must be rectangular and contain only numerical values")]
        public void StringConstructorExceptionTest()
        {

            string elements = "3   1  \n4   \n5 1";
            MyMatrix matrix = new MyMatrix(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The matrix must be rectangular and contain only numerical values")]
        public void StringConstructorExceptionWithLettersTest()
        {
            string elements = "3   ö  \n4  w \n5 1";
            new MyMatrix(elements);
        }

        [TestMethod]
        public void ToStringTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }};
            MyMatrix matrix = new MyMatrix(elements);

            string output = "1\t2\t3\n4\t5\t6\n7\t8\t9";

            Assert.AreEqual(matrix.ToString(), output);
        }

        [TestMethod]
        public void HeightPropertyTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix.Height, 4);
        }

        [TestMethod]
        public void WidthPropertyTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix.Width, 3);
        }

        [TestMethod]
        public void GetHeightMethodTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix.GetHeight(), 4);
        }

        [TestMethod]
        public void GetWidthMethodTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix.GetWidth(), 3);
        }

        [TestMethod]
        public void GetPropertyTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix[2, 0], 7);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void GetPropertyFirstIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            double element = matrix[4, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void GetPropertySecondIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            double element = matrix[2, 3];
        }

        [TestMethod]
        public void SetPropertyTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix[2, 0] = 10;

            Assert.AreEqual(matrix[2, 0], 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void SetPropertyFirstIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix[4, 1] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void SetPropertySecondIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix[2, 3] = 10;
        }

        [TestMethod]
        public void GetElementMethodTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);

            Assert.AreEqual(matrix.GetElement(2, 2), 9);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void GetElementMethodFirstIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            double element = matrix.GetElement(4, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void GetElementMethodSecondIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            double element = matrix.GetElement(2, 3);
        }

        [TestMethod]
        public void SetElementMethodTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix.SetElement(2, 2, 8);

            Assert.AreEqual(matrix[2, 2], 8);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void SetElementMethodFirstIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix.SetElement(4, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrect index value")]
        public void SetElementMethodSecondIndexExceptionTest()
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            matrix.SetElement(2, 3, 10);
        }

        [TestMethod]
        public void MatrixAdditionTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            double[,] elements2 = { { 0, 1, 2 }, { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 }};
            MyMatrix matrix2 = new MyMatrix(elements2);

            MyMatrix result = matrix1 + matrix2;
            double[,] expectedResult = { { 1, 3, 5 }, { 11, 13, 15 }, { 11, 13, 15 }, { 1, 3, 5 } };

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    Assert.AreEqual(result[i, j], expectedResult[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The height and width of the first matrix must be " +
            "equal to the height and width of the second one accordingly")]
        public void MatrixAdditionRowExceptionTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }};
            MyMatrix matrix1 = new MyMatrix(elements1);

            double[,] elements2 = { { 0, 1, 2 }, { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };
            MyMatrix matrix2 = new MyMatrix(elements2);

            MyMatrix result = matrix1 + matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The height and width of the first matrix must be " +
            "equal to the height and width of the second one accordingly")]
        public void MatrixAdditionColomnExceptionTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            double[,] elements2 = { { 0, 1, 2, 0 }, { 7, 8, 9, 0 }, { 4, 5, 6, 0 }, { 1, 2, 3, 0 } };
            MyMatrix matrix2 = new MyMatrix(elements2);

            MyMatrix result = matrix1 + matrix2;
        }

        [TestMethod]
        public void MatrixMultiplicationTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, {7, 8, 9 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            double[,] elements2 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            MyMatrix matrix2 = new MyMatrix(elements2);

            MyMatrix result = matrix1 * matrix2;
            double[,] expectedResult = { { 22, 28 }, { 49, 64 }, { 76, 100 } };

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    Assert.AreEqual(result[i, j], expectedResult[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The width of the first matrix must be equal to " +
                    "the height of the second one")]
        public void MatrixMultiplicationExceptionTest()
        {
            double[,] elements1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            double[,] elements2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MyMatrix matrix2 = new MyMatrix(elements2);

            MyMatrix result = matrix1 * matrix2;
        }

        [TestMethod]
        public void GetTransponedCopyTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            MyMatrix transponed = matrix1.GetTransponedCopy();
            double[,] expectedResult = { { 1, 4, 7, 0 }, { 2, 5, 8, 1 }, { 3, 6, 9, 2 } };

            for (int i = 0; i < transponed.Height; i++)
            {
                for (int j = 0; j < transponed.Width; j++)
                {
                    Assert.AreEqual(transponed[i, j], expectedResult[i, j]);
                }
            }
        }

        [TestMethod]
        public void TransponeMeTest()
        {
            double[,] elements1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix1 = new MyMatrix(elements1);

            matrix1.TransponeMe();

            double[,] expectedResult = { { 1, 4, 7, 0 }, { 2, 5, 8, 1 }, { 3, 6, 9, 2 } };

            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix1.Width; j++)
                {
                    Assert.AreEqual(matrix1[i, j], expectedResult[i, j]);
                }
            }
        }
    }
}
