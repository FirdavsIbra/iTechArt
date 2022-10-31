using AutoMapper;
using iTechArt.Database.Entities.Airports;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Database.Entities.Police;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Database.Entities.Students;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IAirport, Airport>().ReverseMap();

            CreateMap<IDoctor, Doctor>().ReverseMap();

            CreateMap<IGrocery, Grocery>();

            CreateMap<IPolice, Police>().ReverseMap();

            CreateMap<IPupil, Pupil>().ReverseMap();

            CreateMap<IStudent, Students>().ReverseMap();
        }
    }
}
