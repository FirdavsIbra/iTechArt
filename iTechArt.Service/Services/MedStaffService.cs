using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class MedStaffService : IMedStaffService
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public MedStaffService(IMedStaffRepository doctorRepository)
        {
            _medStaffRepository = doctorRepository;
        }

        /// <summary>
        /// Takes filestream
        /// </summary>
        public async Task<IMedStaff[]> ExportMedStaffFile()
        {
            return await _medStaffRepository.GetAll();
        }

        /// <summary>
        /// Takes no input so far
        /// </summary>
        public async Task<IMedStaff[]> ImportMedStaffFile()
        {
            return await _medStaffRepository.GetAll();
        }
    }
}
