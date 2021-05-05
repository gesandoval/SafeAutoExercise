using System.Collections.Generic;

namespace SafeAutoExercise.Models{
    public class Driver {

        public int Id { get; set; }
        public string DriverName { get; set; }
        public IList<Trip> Trips { get; private set; } = new List<Trip>();
    }
}