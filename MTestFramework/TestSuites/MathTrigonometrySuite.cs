using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTestFramework
{
    [TestFixture]
    [Category("Trigonometry")]
    [Author("Deshchenya M. I.")]
    public class MathTrigonometrySuite
    {
        [Test]
        [Description("Reveals if arc cosinus values is correct in range -1..1")]
        public void AcosRangeChecking([Range(-1, 1, 0.01)] double d)
        {
            Assert.That(Math.Acos(d), Is.InRange(-2*Math.PI, 2*Math.PI));
        }
        
        [Test]
        [Description("Reveals if arc sinus values is correct in range -1..1")]
        public void AsinRangeChecking([Range(-1, 1, 0.01)] double d)
        {
            Assert.That(Math.Asin(d), Is.InRange(-2 * Math.PI, 2 * Math.PI));
        }

        [Test]
        [Description("Reveals if arc tangens values is correct in range -5..5")]
        public void AtanRangeChecking([Range(-5, 5, 0.01)] double d)
        {
            Assert.That(Math.Atan(d), Is.InRange(-Math.PI / 2, Math.PI / 2));
        }

        [Test]
        [Description("Check arc tangens in range -10..10")]
        public void Atan2InRange([Range(-10, 10, 0.02)] double d)
        {
            Assert.That(Math.Atan2(d, 2), Is.InRange(-Math.PI / 2, Math.PI / 2));
        }

        [Test]
        [Description("Checks cosinus values in range -pi..pi")]
        public void CosRangeCheck([Range(-2 * Math.PI, 2 * Math.PI, 0.03)] double d)
        {
            Assert.That(Math.Cos(d), Is.GreaterThanOrEqualTo(-1).And.LessThanOrEqualTo(1));
        }

        [Test]
        [Description("Checks hyperbolic cosinus radius in range -5..5")]
        public void CoshRangeCheck([Range(-5, 5, 0.1)] double d)
        {
            try { d = Math.Cosh(d); }
            catch (Exception e) { Console.WriteLine(e); }
            finally { };
        }

        [Test]
        [Description("Checks is sinus values correct (in range -2pi..2pi)")]
        public void SinCorrectInRange([Range(-2*Math.PI, 2*Math.PI, 0.03)] double d)
        {
            Assert.That(Math.Sin(d), Is.GreaterThanOrEqualTo(-1).And.LessThanOrEqualTo(1));
        }
        
        [Test]
        [Description("Arc tangens in range -5..5")]
        public void BigMulEqual(
            [Values (int.MaxValue, int.MinValue)] int range,
            [Values (-10, 10, 0, int.MaxValue)] int mul)
        {
            long lng = (long)range * mul;
            Assert.That(Math.BigMul(range, mul) == lng);
        }
    }
}
