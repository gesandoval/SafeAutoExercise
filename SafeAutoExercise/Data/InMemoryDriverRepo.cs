using System.Collections.Generic;
using Commander.Data;
using SafeAutoExercise.Models;
using System.Linq;

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

        IEnumerable<Driver> IDriverRepo.GetAllDrivers()
        {
            return _context.Drivers.ToList<Driver>();
        }

        Driver IDriverRepo.GetDriverById(int id)
        {
            return _context.Drivers.Single<Driver>(a => a.Id == id );
        }

        bool IDriverRepo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}