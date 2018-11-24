using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTestFramework
{
    [TestFixture]
    [Category("Aryphmetics")]
    [Author("Deshchenya M. I.")]
    class MathAryphmeticSuite
    {
        [Test]
        [Description("Whole numbers absolute values")]
        public void LongModulus([Values(long.MaxValue, long.MinValue + 1, 0)] long lng)
        {
            Assert.That(Math.Abs(lng), Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [Description("Float point numbers absolute values")]
        public void DoubleModulus([Values(double.MaxValue, double.MinValue, 0)] double dbl)
        {
            Assert.That(Math.Abs(dbl), Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [Description("Checks is signatures revealing correctly")]
        public void CaseSign([Values(int.MinValue, 0, int.MaxValue)] decimal d)
        {
            Assert.AreEqual(Math.Sign(d), signature(d));
        }

        public int signature(decimal i)
        {
            if (i < 0) return -1;
            else if (i > 0) return 1;
            else return 0;
        }

        [TestCaseSource(typeof(EqualsDataGiver), nameof(EqualsDataGiver.ObjectsPair))]
        [Description("Two int objects comparison")]
        public void EqualsTest(int a, int b)
        {
            Assert.That(Math.Equals(a, b), Is.EqualTo(b == a));
        }

        public class EqualsDataGiver
        {
            public static IEnumerable<object> ObjectsPair()
            {
                yield return new TestCaseData(-1, 1);
                yield return new TestCaseData(0, 0);
                yield return new TestCaseData(-99, -99);
            }
        }
    }
}
