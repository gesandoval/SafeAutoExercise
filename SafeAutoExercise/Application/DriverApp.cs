using System.Collections.Generic;
using AutoMapper;
using SafeAutoExercise.Data;
using SafeAutoExercise.Dtos;
using SafeAutoExercise.Models;
using SafeAutoExercise.Common;
using System.Linq;
using System;

namespace SafeAutoExercise.Application{
    public class DriverApp : IDriverApp
    {
        private readonly IDriverRepo _repository;
        private readonly IMapper _mapper;

        public DriverApp(IDriverRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        IEnumerable<DriverReadDto> IDriverApp.GetAllDrivers()
        {
            var drivers = _repository.GetAllDrivers();

            return _mapper.Map<IEnumerable<DriverReadDto>>(drivers);
        }

        DriverReadDto IDriverApp.GetDriver(int id)
        {
            var d = _repository.GetDriverById(id);
            if (d != null)
                return _mapper.Map<DriverReadDto>(d);
            else
                return null;
        }
        IEnumerable<DriverReportDto> IDriverApp.GetDriversReport()
        {
            IList<DriverReportDto> driversReport = new List<DriverReportDto>();

            var drivers = _repository.GetAllDrivers();
            foreach (var driver in drivers)
            {
                //CALCULATE SPEED FOR ALL TRIPS
                var tripsCalculated = driver.Trips
                      .Select(d => new 
                      {
                          DriverName = driver.DriverName,
                          Miles = d.Miles,
                          Speed = HelperCalculation.CalculateSpeedMPH(d.StartTime, d.EndTime, d.Miles)
                      });

                //GROUP ALL TRIPS AND CALCULATE AVERAGE SPEED AND TOTAL MILES
                //EXCLUDE TRIPS WITH LESS THAN 5MPH OR MORE THAN 100MPH
                if (tripsCalculated.Count() > 0)
                {
                    var dto = tripsCalculated
                           .Where(i => i.Speed >= 5 && i.Speed <= 100)
                           .GroupBy(i => i.DriverName)
                           .Select(g => new DriverReportDto
                           {
                               DriverName = driver.DriverName,
                               Miles = Convert.ToInt32(Math.Round(g.Sum(i => i.Miles), 0)),
                               Speed = Convert.ToInt32(Math.Round(g.Average(i => i.Speed), 0))
                           }).FirstOrDefault();
                    driversReport.Add(dto);
                }
            }
            return driversReport;
        }
    }
}