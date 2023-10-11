using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task1
{
    public partial class MyMatrix
    {
        private double[,] elements;

        public MyMatrix(MyMatrix previousMatrix)
        {
            elements = new double[previousMatrix.elements.GetLength(0), previousMatrix.elements.GetLength(1)];

            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    elements[i, j] = previousMatrix.elements[i, j];
                }
            }
            //elements = previousMatrix.elements;
        }

        public MyMatrix(double[,] elements)
        {
            this.elements = elements;
        }

        public MyMatrix(double[][] elements)
        {
            this.elements = new double[elements.Length, elements[0].Length];

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Length == elements[0].Length)
                {
                    for (int j = 0; j < elements[i].Length; j++)
                    {
                        this.elements[i, j] = elements[i][j];
                    }
                }
                else
                {
                    throw new Exception("The matrix must be rectangular");
                }
            }
        }

        public MyMatrix(string[] elements)
        {
            this.elements = new double[elements.Length, elements[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length];
            for (int i = 0; i < elements.Length; i++)
            {
                string[] currentRow = elements[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (elements[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == currentRow.Length
                    && String.Join("", currentRow).All(char.IsDigit))
                {
                    double[] line = Array.ConvertAll(currentRow, double.Parse);
                    for (int j = 0; j < line.Length; j++)
                    {
                        this.elements[i, j] = line[j];
                    }
                }
                else
                {
                    throw new Exception("The matrix must be rectangular and contain only numerical values");
                }
            }
        }

        public MyMatrix(string elements)
        {
            string[] rowsElements = elements.Split('\n');
            this.elements = new double[rowsElements.Length, rowsElements[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length];
            for (int i = 0; i < rowsElements.Length; i++)
            {
                string[] currentRow = rowsElements[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (rowsElements[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == currentRow.Length
                    && String.Join("", currentRow).All(char.IsDigit))
                {
                    double[] line = Array.ConvertAll(currentRow, double.Parse);
                    for (int j = 0; j < line.Length; j++)
                    {
                        this.elements[i, j] = line[j];
                    }
                }
                else
                {
                    throw new Exception("The matrix must be rectangular and contain only numerical values");
                }
            }
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    output += elements[i, j].ToString() + "\t";
                }
                output = output.TrimEnd('\t');
                output += "\n";
            }

            output = output.TrimEnd('\n');
            return output;
        }

        public int Height
        {
            get
            {
                return elements.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return elements.GetLength(1);
            }
        }

        public int GetHeight()
        {
            return elements.GetLength(0);
        }

        public int GetWidth()
        {
            return elements.GetLength(1);
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= 0 && j >= 0 && i < elements.GetLength(0) && j < elements.GetLength(1))
                {
                    return elements[i, j];
                }
                else
                {
                    throw new IndexOutOfRangeException("Incorrect indexes value");
                }
            }
            set
            {
                if (i >= 0 && j >= 0 && i < elements.GetLength(0) && j < elements.GetLength(1))
                {
                    elements[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Incorrect indexes value");
                }
            }
        }

        public double GetElement(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < elements.GetLength(0) && j < elements.GetLength(1))
            {
                return elements[i, j];
            }
            else
            {
                throw new IndexOutOfRangeException("Incorrect indexes value");
            }
        }

        public void SetElement(int i, int j, double value)
        {
            if (i >= 0 && j >= 0 && i < elements.GetLength(0) && j < elements.GetLength(1))
            {
                elements[i, j] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Incorrect indexes value");
            }
        }
    }
}
