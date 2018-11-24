using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTestFramework.TestedClasses
{
    public class Man
    {
        public int Weight;
        public int Height;
        public byte Age;
        public ActivityLevel Activity;

        public bool IsWeightNormal;
        public double MinDailyCalories;
        public double MaxDailyCalories;

        public Man(int weight, int height, byte age, ActivityLevel activity)
        {
            Weight = weight;
            Height = height;
            Age = age;
            Activity = activity;
            IsWeightNormal = new bool();
            MinDailyCalories = new double();
            MaxDailyCalories = new double();
        }
    }
}
