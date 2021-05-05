using System.Collections.Generic;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Data{
    public class MockDriverRepo : IDriverRepo
    {
        void IDriverRepo.CreateDriver(Driver driver)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Driver> IDriverRepo.GetAllDrivers()
        {
            var drivers = new List<Driver>{
                new Driver(){ Id=1, DriverName="Dan" },
                new Driver(){ Id=2, DriverName="Jeff" },
                new Driver(){ Id=3, DriverName="Guillermo" },
                new Driver(){ Id=4, DriverName="Logan" }
            };
            return drivers;
        }

        Driver IDriverRepo.GetDriverById(int id)
        {
            return new Driver(){ Id=0, DriverName="Dan" };
        }

        bool IDriverRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}