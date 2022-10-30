using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

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

            if (fileExtension == ".xlsx")
            {
                await ExcelParser(file);
            }
        }

        private async Task ExcelParser(IFormFile file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var medStaff = new MedStaffDTO()
                            {
                                FirstName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                LastName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Gender = (Gender)Convert.ToByte(worksheet.Cells[row, 3].Value),
                                Email = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                PhoneNumber = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                DateOfBirth = Convert.ToDateTime(worksheet.Cells[row, 6].Value),
                                Address = worksheet.Cells[row, 7].Value.ToString(),
                                Salary = Convert.ToDecimal(worksheet.Cells[row, 8].Value),
                                HospitalName = worksheet.Cells[row, 9].Value.ToString(),
                                PostalCode = worksheet.Cells[row, 10].Value is null? string.Empty : worksheet.Cells[row, 10].Value.ToString().Trim(),
                                Shift = (Shift)Convert.ToByte(worksheet.Cells[row, 11].Value)
                            };

                            await _medStaffRepository.AddAsync(medStaff);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(ex));
            }
        }
    }
}
