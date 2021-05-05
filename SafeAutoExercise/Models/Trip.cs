using System;

namespace SafeAutoExercise.Models{
    public class Trip
    {
        public int Id { get; set; }

        public Driver Driver { get; set; }
        public int DriverId { get; set; }

        public TimeSpan StartTime { get; set; }


        public TimeSpan EndTime { get; set; }


        public Double Miles { get; set; }
    }
}