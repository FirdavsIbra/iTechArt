using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

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

        private async Task ExcelParser(IFormFile file)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        private async Task CsvParser(IFormFile file)
        {

        }

        private async Task XmlParser(IFormFile file)
        {

        }
    }
}
