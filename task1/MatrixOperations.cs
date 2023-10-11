using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            double[,] elements = new double[matrix1.Height, matrix1.Width];

            if (matrix1.Height == matrix2.Height && matrix1.Width == matrix2.Width)
            {
                for (int i = 0; i < matrix1.Height; i++)
                {
                    for (int j = 0; j < matrix1.Width; j++)
                    {
                        elements[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
            }
            else
            {
                throw new Exception("The height and width of the first matrix must be equal to " +
                    "the height and width of the second one accordingly");
            }

            return new MyMatrix(elements);
        }

        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            double[,] elements = new double[matrix1.Height, matrix2.Width];

            if (matrix1.Width == matrix2.Height)
            {
                for (int i = 0; i < matrix1.Height; i++)
                {
                    for (int j = 0; j < matrix2.Width; j++)
                    {
                        elements[i, j] = 0;

                        for (int k = 0; k < matrix1.Width; k++)
                        {
                            elements[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            else
            {
                throw new Exception("The width of the first matrix must be equal to " +
                    "the height of the second one");
            }

            return new MyMatrix(elements);
        }

        private double[,] GetTransponedArray()
        {
            double[,] transponed;
            transponed = new double[elements.GetLength(1), elements.GetLength(0)];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    transponed[j, i] = elements[i, j];
                }
            }

            return transponed;
        }

        public MyMatrix GetTransponedCopy()
        {
            double[,] transponed = GetTransponedArray();
            return new MyMatrix(transponed);
        }

        public void TransponeMe()
        {
            elements = GetTransponedArray();
        }
    }
}
