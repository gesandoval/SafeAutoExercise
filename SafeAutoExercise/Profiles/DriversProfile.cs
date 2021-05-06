using AutoMapper;
using SafeAutoExercise.Dtos;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Profiles{
    public class DriverProfile : Profile
    {
        public DriverProfile(){
            CreateMap<Driver, DriverReadDto>();
            CreateMap<Trip, TripReadDto>();
        }

    }
}