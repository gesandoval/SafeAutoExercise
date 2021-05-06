using System.Collections.Generic;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Data
{
    public interface IDriverRepo
    {
        bool SaveChanges();

        IEnumerable<Driver> GetAllDrivers();
        Driver GetDriverById(int id);
        Driver GetDriverByName(string name);
        void CreateDriver(Driver driver);
        void UpdateDriver(Driver driver);

    }
}
