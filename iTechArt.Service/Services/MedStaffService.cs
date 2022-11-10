using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Service.Services
{
    public sealed class MedStaffService : IMedStaffService
    {
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IMedStaffParser _medStaffParser;

        public MedStaffService(IMedStaffRepository medStaffRepository, IMedStaffParser medStaffParser)
        {
            _medStaffRepository = medStaffRepository;
            _medStaffParser = medStaffParser;
        }

        /// <summary>
        /// Takes no input so far.
        /// </summary>
        public async Task<IMedStaff[]> ExportMedStaffFileAsync()
        {
            return await _medStaffRepository.GetAllAsync();
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task CSVParseAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".csv")
            {
                await _medStaffParser.ParseCSVAsync(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task ExcelParseAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await _medStaffParser.ParseExcelAsync(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface.
        /// </summary>
        public async Task XMLParseAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xml")
            {
                await _medStaffParser.ParseXMLAsync(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Takes filestream.
        /// </summary>
        public async Task ImportMedStaffFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await _medStaffParser.ParseExcelAsync(file);
            }
            else if (fileExtension == ".csv")
            {
                await _medStaffParser.ParseCSVAsync(file);
            }
            else if (fileExtension == ".xml")
            {
                await _medStaffParser.ParseXMLAsync(file);
            }
        }
    }
}
