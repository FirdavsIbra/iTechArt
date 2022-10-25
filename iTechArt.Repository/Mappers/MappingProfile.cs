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
            // map from IAirport to AirportDb
            CreateMap<IAirport, AirportDb>();
            // map from AirportDb to AirportBm
            CreateMap<AirportDb, BusinessModels.Airport>();


            // map from IDoctor to DoctorDb
            CreateMap<IDoctor, DoctorDb>().ReverseMap();
            // map from DoctorDb to DoctorBm
            CreateMap<DoctorDb, BusinessModels.Doctor>();
            

            // map from IGrocery to GroceryDb
            CreateMap<IGrocery, GroceryDb>().ReverseMap();
            // map from GroceryDb to GroceryBm
            CreateMap<GroceryDb, BusinessModels.Grocery>();

            
            // map from IPolice to PoliceDb
            CreateMap<IPolice, PoliceDb>().ReverseMap();
            // map from PoliceDb to PoliceBm
            CreateMap<PoliceDb, BusinessModels.Police>();

            // map from IPupil to PupilDb
            CreateMap<IPupil, PupilDb>();
            // map from PupilDb to PupilBm
            CreateMap<PupilDb, BusinessModels.Pupil>();

            
            // map from IStudent to StudentDb
            CreateMap<IStudent, StudentDb>().ReverseMap();
            // map from StudentDb to StudentBm
            CreateMap<StudentDb, BusinessModels.Student>();
        }
    }
}
