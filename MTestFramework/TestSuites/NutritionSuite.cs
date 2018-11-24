using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MTestFramework.TestedClasses;

namespace MTestFramework
{
    [Author("Deshchenya M. I.")]
    [Category("Nutrition")]
    [TestFixtureSource(typeof(MyFixtureData), nameof(MyFixtureData.FixtureParms))]
    public class NutritionSuite
    {
        private Man man;
        private int ExpMinCalories;
        private int ExpMaxCalories;
        private object ExpLogic;

        public NutritionSuite(Man man, int ExpMinCalories, int ExpMaxCalories, object logic)
        {
            this.man = man;
            this.ExpMinCalories = ExpMinCalories;
            this.ExpMaxCalories = ExpMaxCalories;
            this.ExpLogic = logic;
        }

        public NutritionSuite(Man man, bool logic): this(man, 0, 0, logic) { }

        public NutritionSuite(Man man, int ExpMin, int ExpMax) : this(man, ExpMin, ExpMax, null) { }

        [Test]
        [Description("Checks recommended calories range for Harris-Benedict formula")]
        public void RecommendedCaloriesChecker()
        {
            if (ExpMinCalories == 0 || ExpMaxCalories == 0) return;
            Nutrition.MinMaxCalories(ref man);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(man.MinDailyCalories, ExpMinCalories);
                Assert.AreEqual(man.MaxDailyCalories, ExpMaxCalories);
            });
        }

        [Test]
        [Description("Checks method conclusion that man weight is normal or not")]
        public void WeightStateChecker()
        {
            if (ExpLogic == null) return;
            Nutrition.IsWeightNormal(ref man);
            Assert.AreEqual(man.IsWeightNormal, (bool)ExpLogic);
        }
    }

    public class MyFixtureData
    {
        public static IEnumerable<object> FixtureParms
        {
            get
            {
                yield return new TestFixtureData(new Man(100, 180, 50, ActivityLevel.Minimum), 2208, 2608);
                yield return new TestFixtureData(new Man(80, 160, 30, ActivityLevel.Hight), 2831, 3231);
                yield return new TestFixtureData(new Man(85, 180, 50, ActivityLevel.Minimum), true);
            }
        }
    }

}
