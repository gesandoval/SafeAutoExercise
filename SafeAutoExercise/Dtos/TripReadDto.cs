using System;

namespace SafeAutoExercise.Dtos{
    public class TripReadDto
    {
        public TimeSpan StartTime { get; set; }


        public TimeSpan EndTime { get; set; }


        public Double Miles { get; set; }
    }
}