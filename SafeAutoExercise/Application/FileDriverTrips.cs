using System;
using System.Collections.Generic;
using System.IO;
using SafeAutoExercise.Data;
using SafeAutoExercise.Models;
using SafeAutoExercise.Common;
using SafeAutoExercise.Common.Enums;

namespace SafeAutoExercise.Application{

    public class FileDriverTrips : IFileDriverTrips
    {
        private readonly IDriverRepo _driverRepo;
        private readonly ITripRepo _tripRepo;
        private char[] delimiterChars = { ' ', '\t' };

        public FileDriverTrips(IDriverRepo driverRepo, ITripRepo tripRepo)
        {
            _driverRepo = driverRepo;
            _tripRepo = tripRepo;
        }

        IEnumerable<Driver> IFileDriverTrips.GetAllDrivers()
        {
            return _driverRepo.GetAllDrivers();
        }

    void IFileDriverTrips.UploadDriverTripsData(MemoryStream msFile)
        {
            msFile.Position = 0; // Rewind!
            List<Driver> drivers = new List<Driver>();
            Dictionary<string, List<Trip>> trips = new Dictionary<string, List<Trip>>();
            try
            {

                //// FOR THE PURPOSE OF THE EXERCISE IT IS ASSUMED THAT ALL DRIVERS ARE FIRST IN THE FILE
                ///  THEN ALL TRIPS.
                ///  We could do some other logic to sort that out but for timing reason I left it as it is.
                using (var reader = new StreamReader(msFile))
                {
                    string[] items;
                    string row;
                    //WE READ ALL LINES OF THE FILE AND WE CREATE (REGISTER) DRIVERS AND THEN THE TRIPS ONCE THE DRIVER WAS REGISTRED.
                    //WE INTEND TO DO ONLY ONE LAP ON THE FILE FOR PERFORMANCE
                    while ((row = reader.ReadLine()) != null)
                    {
                        items = row.Split(delimiterChars);
                        if (items[0].Equals(LineCommand.Driver.Value))
                        {
                            ///CREATE DRIVERS
                            Driver d = new Driver() { DriverName = items[1] };
                            _driverRepo.CreateDriver(d);
                            drivers.Add(d);
                        }
                        else if (items[0].Equals(LineCommand.Trip.Value))
                        {
                            //VALIDATIONS ABOUT THE LINE TO BE PROCESSED SHOULD BE APPLIED HERE
                            //DUE TO SIMPLICITY OF THE EXERCISE WILL ASUME ALL DATA IS VALID
                            
                            //First we find the DRIVER TO ASSIGN THE TRIP
                            var driverKey = items[1];
                            var driver = drivers.Find(x => x.DriverName == driverKey);
                            //IF A LINE WITH NON-REGISTRED DRIVER IS PASSED ON, THE LINE IS DISCARTED
                            if (driver != null)
                            {
                                var startTime = HelperTransform.StringHHMMToTimeSpan(items[2]);
                                var endTime = HelperTransform.StringHHMMToTimeSpan(items[3]);
                                var miles = Convert.ToDouble(items[4]);

                                var t = new Trip() { DriverId = driver.Id, StartTime = startTime, EndTime = endTime, Miles = miles };
                                _tripRepo.CreateTrip(t);
                            }
                        }
                    }
                }
            } catch (Exception e)
            {
                ///IN CASE SOMETHING GOES WRONG WE TRHROW AN EXCEPTION
                throw new Exception("Incorrect file", e);
            }
        }
    }
}