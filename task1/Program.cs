using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] elements = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 } };
            MyMatrix matrix = new MyMatrix(elements);
            Console.WriteLine(matrix);

            MyMatrix matrix1 = new MyMatrix(matrix);
            Console.WriteLine("\n" + matrix1);

            double[][] elements2 = new double[3][];
            elements2[0] = new double[] { 1, 2, 3, 4 };
            elements2[1] = new double[] { 5, 6, 7, 8 };
            elements2[2] = new double[] { 9, 0, 1, 2 };
            MyMatrix matrix2 = new MyMatrix(elements2);
            Console.WriteLine("\n" + matrix2);

            string[] elements3 = { "2 3  1", "3 2    2", "4 3 1 " };
            MyMatrix matrix3 = new MyMatrix(elements3);
            Console.WriteLine("\n" + matrix3);

            string elements4 = "3   1  \n4   1\n5 1";
            MyMatrix matrix4 = new MyMatrix(elements4);
            Console.WriteLine("\n" + matrix4);

            Console.WriteLine($"Matrix height = {matrix4.Height}, Matrix width = {matrix4.Width}");
            Console.WriteLine($"Matrix height = {matrix4.GetHeight()}, Matrix width = {matrix4.GetWidth()}");

            matrix4[0, 1] = 9;
            Console.WriteLine("\n" + matrix4);
            Console.WriteLine($"Changed element value = {matrix4[0, 1]}");

            matrix4.SetElement(0, 1, 1);
            Console.WriteLine("\n" + matrix4);
            Console.WriteLine($"Changed element value = {matrix4.GetElement(0, 1)}");

            Console.WriteLine($"\nAdded the first two matrixes:\n{matrix + matrix1}");

            Console.WriteLine($"\nMultiplied the last two matrixes:\n{matrix3 * matrix4}");

            MyMatrix transponed = matrix4.GetTransponedCopy();
            Console.WriteLine($"\nTransponed the last matrix:\n{transponed}");
            Console.WriteLine("\n" + matrix4);

            matrix4.TransponeMe();
            Console.WriteLine($"\nTransponed the last matrix:\n{matrix4}");
            Console.WriteLine("\n" + matrix4);
        }
    }
}
