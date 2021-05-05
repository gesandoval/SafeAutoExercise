using System.Collections.Generic;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Data
{
    public interface ITripRepo
    {
        bool SaveChanges();

        IEnumerable<Trip> GetAllTrips(int drvierId);

        void CreateTrip(Trip trip);

    }
}
