using AutoMapper;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Service.DTOs;

namespace iTechArt.Service.MappersServiceProfile
{
    public sealed class MappersServiceProfile : Profile
    {
        public MappersServiceProfile()
        {
            // map from IAirport to AirportDb
            CreateMap<IAirport, AirportDTO>();
        }
    }
}
