using System.Collections.Generic;
using SafeAutoExercise.Dtos;

namespace SafeAutoExercise.Application{
    public interface IDriverApp{
        IEnumerable<DriverReadDto> GetAllDrivers();

        DriverReadDto GetDriver(int id);

        IEnumerable<DriverReportDto>GetDriversReport();

    }
}