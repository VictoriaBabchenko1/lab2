using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2;
using System;

namespace MyFracTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFracReduction()
        {
            MyFrac frac1 = new MyFrac(4, 2);
            Assert.AreEqual(frac1.Nom, 2);
            Assert.AreEqual(frac1.Denom, 1);

            MyFrac frac2 = new MyFrac(3, 2);
            Assert.AreEqual(frac2.Nom, 3);
            Assert.AreEqual(frac2.Denom, 2);
        }

        [TestMethod]
        public void TestNegativeFracReduction()
        {
            MyFrac frac1 = new MyFrac(-4, -2);
            Assert.AreEqual(frac1.Nom, 2);
            Assert.AreEqual(frac1.Denom, 1);

            MyFrac frac2 = new MyFrac(1, -2);
            Assert.AreEqual(frac2.Nom, -1);
            Assert.AreEqual(frac2.Denom, 2);

            MyFrac frac3 = new MyFrac(-3, 2);
            Assert.AreEqual(frac3.Nom, -3);
            Assert.AreEqual(frac3.Denom, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "The denominator must not contain zero value")]
        public void TestDivisionByZero()
        {
            new MyFrac(4, 0);
            //var ex = Assert.ThrowsException<DivideByZeroException>(() => new MyFrac(4, 0));
            //Assert.AreSame(ex.Message, "The denominator must not contain zero value");
        }

        [TestMethod]
        public void TestToString()
        {
            MyFrac frac1 = new MyFrac(4, 2);
            Assert.AreEqual(frac1.ToString(), "2/1");

            MyFrac frac2 = new MyFrac(-3, -2);
            Assert.AreEqual(frac2.ToString(), "3/2");

            MyFrac frac3 = new MyFrac(3, -2);
            Assert.AreEqual(frac3.ToString(), "-3/2");

            MyFrac frac4 = new MyFrac(-3, 2);
            Assert.AreEqual(frac4.ToString(), "-3/2");
        }

        [TestMethod]
        public void TestToStringWithIntPart()
        {
            MyFrac frac1 = new MyFrac(4, 2);
            Assert.AreEqual(frac1.ToStringWithIntPart(), "(2+0/1)");

            MyFrac frac2 = new MyFrac(-3, -2);
            Assert.AreEqual(frac2.ToStringWithIntPart(), "(1+1/2)");

            MyFrac frac3 = new MyFrac(3, -2);
            Assert.AreEqual(frac3.ToStringWithIntPart(), "-(1+1/2)");

            MyFrac frac4 = new MyFrac(-3, 2);
            Assert.AreEqual(frac4.ToStringWithIntPart(), "-(1+1/2)");
        }

        [TestMethod]
        public void TestDoubleValue()
        {
            MyFrac frac1 = new MyFrac(4, 2);
            Assert.AreEqual(frac1.DoubleValue(), 2);

            MyFrac frac2 = new MyFrac(3, -2);
            Assert.AreEqual(frac2.DoubleValue(), -1,5);
        }

        [TestMethod]
        public void TestAddition()
        {
            MyFrac frac1 = new MyFrac(4, 2);

            MyFrac frac2 = new MyFrac(3, -2);

            MyFrac result = frac1 + frac2;

            Assert.AreEqual(result.Nom, 1);
            Assert.AreEqual(result.Denom, 2);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            MyFrac frac1 = new MyFrac(4, 2);

            MyFrac frac2 = new MyFrac(3, -2);

            MyFrac result = frac1 - frac2;

            Assert.AreEqual(result.Nom, 7);
            Assert.AreEqual(result.Denom, 2);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            MyFrac frac1 = new MyFrac(4, 2);

            MyFrac frac2 = new MyFrac(3, -2);

            MyFrac result = frac1 * frac2;

            Assert.AreEqual(result.Nom, -3);
            Assert.AreEqual(result.Denom, 1);
        }

        [TestMethod]
        public void TestDivision()
        {
            MyFrac frac1 = new MyFrac(4, 2);

            MyFrac frac2 = new MyFrac(3, -2);

            MyFrac result = frac1 / frac2;

            Assert.AreEqual(result.Nom, -4);
            Assert.AreEqual(result.Denom, 3);
        }

        [TestMethod]
        public void TestCalcExpr1()
        {
            MyFrac result = MyFrac.CalcExpr1(5);

            MyFrac correctResult = new MyFrac(5, 5 + 1);

            Assert.AreEqual(result.Nom, result.Nom);
            Assert.AreEqual(result.Denom, correctResult.Denom);
        }

        [TestMethod]
        public void TestCalcExpr2()
        {
            MyFrac result = MyFrac.CalcExpr2(5);

            MyFrac correctResult = new MyFrac(5 + 1, 2 * 5);

            Assert.AreEqual(result.Nom, result.Nom);
            Assert.AreEqual(result.Denom, correctResult.Denom);
        }
    }
}
