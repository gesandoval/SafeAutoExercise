using System.Collections.Generic;
using Commander.Data;
using SafeAutoExercise.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SafeAutoExercise.Data{
    public class InMemoryDriverRepo : IDriverRepo
    {

        private readonly ApplicationDBContext _context;

        public InMemoryDriverRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        void IDriverRepo.CreateDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        void IDriverRepo.UpdateDriver(Driver driver)
        {
            _context.Update(driver);
            _context.SaveChanges();
        }

        IEnumerable<Driver> IDriverRepo.GetAllDrivers()
        {
            
            return _context.Drivers.Include(trip => trip.Trips).ToList<Driver>();
        }

        Driver IDriverRepo.GetDriverById(int id)
        {
            return _context.Drivers.Any(o => o.Id == id) ? 
                        _context.Drivers.Include(trip => trip.Trips).Single<Driver>(a => a.Id == id ) :
                        null;
        }

        Driver IDriverRepo.GetDriverByName(string name)
        {
            return _context.Drivers.Any(o => o.DriverName == name) ?
                        _context.Drivers.Single(o => o.DriverName == name) :
                        null;
        }

        bool IDriverRepo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}