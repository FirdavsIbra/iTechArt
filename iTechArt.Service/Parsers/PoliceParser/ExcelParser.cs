using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace iTechArt.Service.Parsers.PoliceParser
{
    public class ExcelParser : IExcelParser
    {
        private readonly IPoliceRepository _policeRepository;

        public ExcelParser(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }

        /// <summary>
        /// Parse XLSX file and save to database
        /// </summary>
        public async Task ReadExcelAsync(IFormFile file)
        {
            var polices = new List<IPolice>();

            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                using (var package = new ExcelPackage(fileStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var policeDto = new PoliceDto
                            {
                                Name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                Surname = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                Gender = (Gender)Convert.ToByte(worksheet.Cells[row, 4].Value),
                                Address = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                JobTitle = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                Salary = Convert.ToDouble(worksheet.Cells[row, 7].Value)
                            };
                            polices.Add(policeDto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception occured with a message: " + ex.Message.ToString());
                        }
                    }
                    await _policeRepository.AddRangeAsync(polices.ToArray());
                }
            }
        }
    }
}
