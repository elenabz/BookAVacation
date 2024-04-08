using AutoMapper;
using BookAVacation.DTO;
using BookAVacation.Models;

namespace BookAVacation.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<PropertyMapAction, PropertyDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
        
        
        }

    }
}
