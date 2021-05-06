using System.Collections.Generic;

namespace SafeAutoExercise.Dtos{
    public class DriverReadDto {

        public int Id { get; set; }
        public string DriverName { get; set; }
        public IList<TripReadDto> Trips { get; private set; } = new List<TripReadDto>();
    }
}