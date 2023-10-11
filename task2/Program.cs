using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFrac frac1 = new MyFrac(3, -2);
            Console.WriteLine(frac1);
            Console.WriteLine(frac1.DoubleValue());
            Console.WriteLine(frac1.ToStringWithIntPart());

            MyFrac frac2 = new MyFrac(4, 2);
            Console.WriteLine("\n" + (frac1 + frac2));
            Console.WriteLine(frac1 - frac2);
            Console.WriteLine(frac1 * frac2);
            Console.WriteLine(frac1 / frac2);

            Console.WriteLine(MyFrac.CalcExpr1(5) + $"\t{new MyFrac(5, 5 + 1)}");
            Console.WriteLine(MyFrac.CalcExpr2(5) + $"\t{new MyFrac(5 + 1, 2 * 5)}");
        }
    }
}