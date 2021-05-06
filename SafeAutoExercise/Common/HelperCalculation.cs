using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeAutoExercise.Common
{
    public class HelperCalculation
    {
        public static double CalculateSpeedMPH(TimeSpan startTime, TimeSpan endTime, Double miles)
        {
            double speed = 0.0;
            var timeSeconds = endTime.TotalSeconds - startTime.TotalSeconds;
            if (timeSeconds != 0)
            {
                speed = (miles / timeSeconds) * 3600;
            }
            return speed;
        }
    }
}
