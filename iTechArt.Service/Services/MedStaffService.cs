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
        /// Takes no input so far
        /// </summary>
        public async Task<IMedStaff[]> ExportMedStaffFile()
        {
            return await _medStaffRepository.GetAllAsync();
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface
        /// </summary>
        public async Task CSVParse(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".csv")
            {
                await _medStaffParser.ParseCSV(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface
        /// </summary>
        public async Task ExcelParse(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await _medStaffParser.ParseExcel(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Parse iformfile into IMedStaff interface
        /// </summary>
        public async Task XMLParse(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xml")
            {
                await _medStaffParser.ParseXML(file);
            }
            else
            {
                throw new ArgumentException("Invalid file format");
            }
        }

        /// <summary>
        /// Takes filestream
        /// </summary>
        public async Task ImportMedStaffFile(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                await _medStaffParser.ParseExcel(file);
            }
            else if (fileExtension == ".csv")
            {
                await _medStaffParser.ParseCSV(file);
            }
            else if (fileExtension == ".xml")
            {
                await _medStaffParser.ParseXML(file);
            }
        }
    }
}
