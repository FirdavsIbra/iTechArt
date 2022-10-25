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
            CreateMap<IAirport, AirportDb>();
            CreateMap<AirportDb, BusinessModels.Airport>();

            CreateMap<IDoctor, DoctorDb>().ReverseMap();
            CreateMap<DoctorDb, BusinessModels.Doctor>();
            
            CreateMap<IGrocery, GroceryDb>().ReverseMap();
            CreateMap<GroceryDb, BusinessModels.Grocery>();

            CreateMap<IPolice, PoliceDb>().ReverseMap();
            CreateMap<PoliceDb, BusinessModels.Police>();

            CreateMap<IPupil, PupilDb>();
            CreateMap<PupilDb, BusinessModels.Pupil>();

            CreateMap<IStudent, StudentDb>().ReverseMap();
            CreateMap<StudentDb, BusinessModels.Student>();
        }
    }
}
