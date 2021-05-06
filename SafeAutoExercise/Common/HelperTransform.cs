using System;

namespace SafeAutoExercise.Common{
    public class HelperTransform{
        public static TimeSpan  StringHHMMToTimeSpan(string value){
            string[] sTime = value.Split(':');
            ///HERE ASSERTTION TO VALID DATA SHOULD BE MADE, FOR SIMPLICITY OF THIS EXERCISE AT THIS TIME WILL ASUME THAT EVERYTHING IS VALID
            var hour = Convert.ToInt32(sTime[0]);
            var min = Convert.ToInt32(sTime[1]);
            return new TimeSpan(hour, min, 0);
        }
    }
}