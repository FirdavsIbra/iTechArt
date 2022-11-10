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
            // Map from IAirport to AirportDb.
            CreateMap<IAirport, AirportDb>();
            // Map from AirportDb to AirportBm.
            CreateMap<AirportDb, BusinessModels.Airport>();


            // Map from IMedStaff to MedStaffDb.
            CreateMap<IMedStaff, MedStaffDb>();
            // Map from MedStaffDb to MedStaffBm.
            CreateMap<MedStaffDb, BusinessModels.MedStaff>();


            // Map from IGrocery to GroceryDb.
            CreateMap<IGrocery, GroceryDb>();
            // Map from GroceryDb to GroceryBm.
            CreateMap<GroceryDb, BusinessModels.Grocery>();


            // Mapping from IPolice to Police Database Model.
            CreateMap<IPolice, PoliceDb>();
            // Mapping from PoliceDb to Police Business Model.
            CreateMap<PoliceDb, BusinessModels.Police>();

            // Map from IPupil to PupilDb.
            CreateMap<IPupil, PupilDb>();
            // Map from PupilDb to PupilBm.
            CreateMap<PupilDb, BusinessModels.Pupil>();


            // Map from IStudent to StudentDb.
            CreateMap<IStudent, StudentDb>();
            // Map from StudentDb to StudentBm.
            CreateMap<StudentDb, BusinessModels.Student>();
        }
    }
}
