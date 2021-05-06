using System.Collections.Generic;
using System.IO;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Application{
    public interface IFileDriverTrips{
        void UploadDriverTripsData (MemoryStream msFile);
        
    }
}