using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class MedStaffService : IMedStaffService
    {
        private readonly IDoctorRepository _doctorRepository;

        public MedStaffService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        /// <summary>
        /// Takes filestream
        /// </summary>
        /// <returns> List of strings </returns>
        public IDoctor[] ExportMedStaffFile()
        {
            return _doctorRepository.GetAll();
        }

        /// <summary>
        /// Takes no input so far
        /// </summary>
        /// <returns> Empty List of string </returns>
        public IDoctor[] ImportMedStaffFile()
        {
            return _doctorRepository.GetAll();
        }
    }
}
