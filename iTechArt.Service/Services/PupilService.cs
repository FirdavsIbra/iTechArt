using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
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
        public async Task<IPupil[]> GetAllAsync()
        {
            return await _pupilRepository.GetAllAsync();
        }

        /// <summary>
        /// Import pupil's file
        /// </summary>
        public async Task ImportPupilsFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
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
                PupilForCreationDto[] pupils = new PupilForCreationDto[rowCount - 1];

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
                    pupils[row - 2] = pupil;
                }
                await _pupilRepository.AddRangeAsync(pupils);
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
            var csvLines = File.ReadAllLines(filePath);

            PupilForCreationDto[] pupils = new PupilForCreationDto[csvLines.Length - 1];

            for (int i = 1; i < csvLines.Length; i++)
            {
                var rowData = csvLines[i].Split(',');

                var pupil = new PupilForCreationDto
                {
                    FirstName = rowData[0].ToString().Trim(),
                    LastName = rowData[1].ToString().Trim(),
                    DateOfBirth = Convert.ToDateTime(rowData[2]),
                    Gender = (Gender)Convert.ToByte(rowData[3]),
                    PhoneNumber = rowData[4].ToString().Trim(),
                    Address = rowData[5].ToString().Trim(),
                    City = rowData[6].ToString().Trim(),
                    SchoolName = rowData[7].ToString().Trim(),
                    Grade = Convert.ToByte(rowData[8]),
                    CourseLanguage = (CourseLanguage)Convert.ToByte(rowData[9]),
                    Shift = (Shift)Convert.ToByte(rowData[10])
                };
                pupils[i - 1] = pupil;
            }
            await _pupilRepository.AddRangeAsync(pupils);

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

            PupilForCreationDto[] pupils = new PupilForCreationDto[xmlDocument.SelectNodes("/pupils/pupil").Count];

            var nodes = xmlDocument.SelectNodes("/pupils/pupil");

            for (int i = 0; i < nodes.Count; i++)
            {
                PupilForCreationDto pupil = new PupilForCreationDto
                {
                    FirstName = nodes[i]["FirstName"].InnerText,
                    LastName = nodes[i]["LastName"].InnerText,
                    DateOfBirth = Convert.ToDateTime(nodes[i]["DateOfBirth"].InnerText),
                    Gender = (Gender)Convert.ToByte(nodes[i]["Gender"].InnerText),
                    PhoneNumber = nodes[i]["PhoneNumber"].InnerText,
                    Address = nodes[i]["Address"].InnerText,
                    City = nodes[i]["City"].InnerText,
                    SchoolName = nodes[i]["SchoolName"].InnerText,
                    Grade = Convert.ToByte(nodes[i]["Grade"].InnerText),
                    CourseLanguage = (CourseLanguage)Convert.ToByte(nodes[i]["CourseLanguage"].InnerText),
                    Shift = (Shift)Convert.ToByte(nodes[i]["Shift"].InnerText)
                };
                pupils[i] = pupil;
            }
            await _pupilRepository.AddRangeAsync(pupils);

            // Delete the created file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
