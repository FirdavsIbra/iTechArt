using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Xml;

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
