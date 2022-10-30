using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupilRepository;
        public PupilService(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        public IPupil[] GetAllAsync()
        {
            return _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file
        /// </summary>
        public async Task ImportPupilsFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx")
            {
                await ExcelParser(file);
            }
            else if (fileExtension == ".csv")
            {
                await CsvParser(file);
            }
            else if (fileExtension == ".xml")
            {
                await XmlParser(file);
            }
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public async Task<IPupil> GetByIdAsync(long id) 
        { 
            return await _pupilRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Add pupil to database
        /// </summary>
        public async Task AddAsync(IPupil pupil)
        {
            await _pupilRepository.AddAsync(pupil);
        }

        /// <summary>
        /// Delete pupil
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            await _pupilRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        private async Task ExcelParser(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using var package = new ExcelPackage(stream);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var pupil = new PupilForCreationDto
                    {
                        FirstName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                        LastName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                        DateOfBirth = Convert.ToDateTime(worksheet.Cells[row, 3].Value),
                        Gender = (Gender)Convert.ToByte(worksheet.Cells[row, 4].Value),
                        PhoneNumber = worksheet.Cells[row, 5].Value.ToString().Trim(),
                        Address = worksheet.Cells[row, 6].Value.ToString().Trim(),
                        City = worksheet.Cells[row, 7].Value.ToString().Trim(),
                        SchoolName = worksheet.Cells[row, 8].Value.ToString().Trim(),
                        Grade = Convert.ToByte(worksheet.Cells[row, 9].Value),
                        CourseLanguage = (CourseLanguage)Convert.ToByte(worksheet.Cells[row, 10].Value),
                        Shift = (Shift)Convert.ToByte(worksheet.Cells[row, 11].Value),
                    };
                    await _pupilRepository.AddAsync(pupil);
                }
            }
            
        }

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        private async Task CsvParser(IFormFile file)
        {
            var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true
            };

            using (StreamReader csvReader = new StreamReader(filePath))
            {
                using CsvReader csv = new(csvReader, configuration);
                //csv.Context.RegisterClassMap<PupilMap>();
                var records = csv.GetRecords<PupilForCreationDto>().ToList();

                foreach (var record in records)
                {
                    PupilForCreationDto pupil = new PupilForCreationDto
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        DateOfBirth = record.DateOfBirth,
                        Gender = record.Gender,
                        PhoneNumber = record.PhoneNumber,
                        Address = record.Address,
                        City = record.City,
                        SchoolName = record.SchoolName,
                        Grade = record.Grade,
                        CourseLanguage = record.CourseLanguage,
                        Shift = record.Shift
                    };
                    await _pupilRepository.AddAsync(pupil);
                }
            }
            // Delete the created file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        private async Task XmlParser(IFormFile file)
        {
            var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            foreach (XmlNode node in xmlDocument.SelectNodes("/pupils/pupil"))
            {
                PupilForCreationDto pupil = new PupilForCreationDto
                {
                    FirstName = node["FirstName"].InnerText,
                    LastName = node["LastName"].InnerText,
                    DateOfBirth = Convert.ToDateTime(node["DateOfBirth"].InnerText),
                    Gender = (Gender)Convert.ToByte(node["Gender"].InnerText),
                    PhoneNumber = node["PhoneNumber"].InnerText,
                    Address = node["Address"].InnerText,
                    City = node["City"].InnerText,
                    SchoolName = node["SchoolName"].InnerText,
                    Grade = Convert.ToByte(node["Grade"].InnerText),
                    CourseLanguage = (CourseLanguage)Convert.ToByte(node["CourseLanguage"].InnerText),
                    Shift = (Shift)Convert.ToByte(node["Shift"].InnerText)
                };
                await _pupilRepository.AddAsync(pupil);
            }
            // Delete the created file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
    //public class PupilMap : ClassMap<PupilForCreationDto>
    //{
    //    public PupilMap()
    //    {
    //        Map(p => p.FirstName).Index(0);
    //        Map(p => p.LastName).Index(1);
    //        Map(p => p.DateOfBirth).Index(2);
    //        Map(p => p.Gender).Index(3);
    //        Map(p => p.PhoneNumber).Index(4);
    //        Map(p => p.Address).Index(5);
    //        Map(p => p.City).Index(6);
    //        Map(p => p.SchoolName).Index(7);
    //        Map(p => p.Grade).Index(8);
    //        Map(p => p.CourseLanguage).Index(9);
    //        Map(p => p.Shift).Index(10);
    //    }
    //}
}
