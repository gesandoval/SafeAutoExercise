using System.Collections.Generic;
using Commander.Data;
using SafeAutoExercise.Models;
using System.Linq;

namespace SafeAutoExercise.Data{
    public class InMemoryTripRepo : ITripRepo
    {

        private readonly ApplicationDBContext _context;

        public InMemoryTripRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        void ITripRepo.CreateTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        IEnumerable<Trip> ITripRepo.GetAllTrips(int drvierId)
        {
            throw new System.NotImplementedException();
        }

        bool ITripRepo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}