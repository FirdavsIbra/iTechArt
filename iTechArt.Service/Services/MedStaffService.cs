using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class MedStaffService : IMedStaffService
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public MedStaffService(IMedStaffRepository doctorRepository)
        {
            _medStaffRepository = doctorRepository;
        }

        /// <summary>
        /// Takes filestream
        /// </summary>
        public IMedStaff[] ExportMedStaffFile()
        {
            return _medStaffRepository.GetAll();
        }

        /// <summary>
        /// Takes no input so far
        /// </summary>
        public IMedStaff[] ImportMedStaffFile()
        {
            return _medStaffRepository.GetAll();
        }
    }
}
