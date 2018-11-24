using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTestFramework.TestedClasses
{
    public static class Nutrition
    {
        public static void IsWeightNormal(ref Man man)
        {
            int a;
            if (man.Age <40) a = man.Height - 110; else a = man.Height - 100;
            if (Math.Abs(a - man.Weight) <= 5) man.IsWeightNormal = true;
                else man.IsWeightNormal = false;
        }

        public static void MinMaxCalories(ref Man man)
        {
            double BMR;
            BMR = 88.36 + (13.4 * man.Weight) + (4.8 * man.Height) - (5.7 * man.Age);
            switch (man.Activity)
            {
                case ActivityLevel.Minimum: BMR *= 1.2;  break;
                case ActivityLevel.Low: BMR *= 1.375; break;
                case ActivityLevel.Medium: BMR *= 1.55; break;
                case ActivityLevel.Hight: BMR *= 1.725; break;
                case ActivityLevel.UltraHight: BMR *= 1.9; break;
                default: break;
            }
            man.MinDailyCalories = Math.Truncate(BMR - 200);
            man.MaxDailyCalories = Math.Truncate(BMR + 200);
        }
    }
}
