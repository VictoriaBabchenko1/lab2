using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    public class MyFrac
    {
        protected long nom;
        protected long denom;

        public MyFrac(long nom, long denom)
        {
            if (denom != 0)
            {
                this.nom = nom;
                this.denom = denom;

                long gcd = FindGcd(this.nom, this.denom);

                this.nom = nom / gcd;
                this.denom = denom / gcd;

                if (this.nom < 0 && this.denom < 0)
                {
                    this.nom = Math.Abs(this.nom);
                    this.denom = Math.Abs(this.denom);
                }
                else if (this.denom < 0)
                {
                    this.nom = -1 * this.nom;
                    this.denom = Math.Abs(this.denom);
                }
            }
            else
            {
                throw new DivideByZeroException("The denominator must not contain zero value");
            }
        }

        private long FindGcd(long nom, long denom)
        {
            nom = Math.Abs(nom);
            denom = Math.Abs(denom);

            if (nom == 0)
            {
                return 1;
            }
            else
            {
                while (nom != 0 && denom != 0)
                {
                    if (nom > denom)
                    {
                        nom %= denom;
                    }
                    else
                    {
                        denom %= nom;
                    }
                }

                long gcd = nom + denom;
                return gcd;
            }
        }

        public long Nom
        {
            get { return nom; }
        }

        public long Denom
        {
            get { return denom; }
        }

        public override string ToString()
        {
            return nom + "/" + denom;
        }

        public string ToStringWithIntPart()
        {
            long whole_part = this.nom / denom;
            long nom = this.nom % denom;

            string str = "(" + Math.Abs(whole_part) + "+" + Math.Abs(nom) + "/" + Math.Abs(denom) + ")";

            if (this.nom < 0 || denom < 0)
            {
                str = "-" + str;
            }

            return str;
        }

        public double DoubleValue()
        {
            return Convert.ToDouble(nom) / Convert.ToDouble(denom);
        }

        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }

        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }

        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }

        public static MyFrac CalcExpr1(int n)
        {
            MyFrac res = new MyFrac(0, 1);

            for (long i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                res += add;
            }

            return res;
        }

        public static MyFrac CalcExpr2(int n)
        {
            MyFrac res = new MyFrac(1, 1);

            for (int i = 2; i <= n; i++)
            {
                MyFrac f1 = new MyFrac(1, 1);
                MyFrac f2 = new MyFrac(1, i * i);
                MyFrac frac = f1 - f2;

                res *= frac;
            }

            return res;
        }
    }
}
