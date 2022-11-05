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
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // map from IAirport to AirportDb
            CreateMap<IAirport, AirportDb>();
            // map from AirportDb to AirportBm
            CreateMap<AirportDb, BusinessModels.Airport>();


            // map from IMedStaff to MedStaffDb
            CreateMap<IMedStaff, MedStaffDb>();
            // map from MedStaffDb to MedStaffBm
            CreateMap<MedStaffDb, BusinessModels.MedStaff>();


            // map from IGrocery to GroceryDb
            CreateMap<List<IGrocery>, GroceryDb>();
            // map from GroceryDb to GroceryBm
            CreateMap<GroceryDb, BusinessModels.Grocery>();


            // mapping from IPolice to Police Database Model
            CreateMap<IPolice, PoliceDb>();
            // mapping from PoliceDb to Police Business Model
            CreateMap<PoliceDb, BusinessModels.Police>();

            // map from IPupil to PupilDb
            CreateMap<IPupil, PupilDb>();
            // map from PupilDb to PupilBm
            CreateMap<PupilDb, BusinessModels.Pupil>();


            // map from IStudent to StudentDb
            CreateMap<IStudents, StudentDb>();
            // map from StudentDb to StudentBm
            CreateMap<StudentDb, BusinessModels.Student>();
        }
    }
}
