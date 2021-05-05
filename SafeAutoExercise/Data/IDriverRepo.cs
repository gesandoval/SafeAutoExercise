using System.Collections.Generic;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Data
{
    public interface IDriverRepo
    {
        bool SaveChanges();

        IEnumerable<Driver> GetAllDrivers();
        Driver GetDriverById(int id);
        void CreateDriver(Driver driver);

    }
}
