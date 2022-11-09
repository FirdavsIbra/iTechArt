using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.IPoliceParsers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseExcel : IExcelParse
    {
        /// <summary>
        /// Parse XLSX or XLS file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseExcelAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
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
                        var policeDto = new PoliceDto
                        {
                            Name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Surname = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Gender = Enum.Parse<Gender>(worksheet.Cells[row, 4].Value.ToString()),
                            Address = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            JobTitle = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Salary = Convert.ToDouble(worksheet.Cells[row, 7].Value)
                        };
                        polices.Add(policeDto);
                    }
                    return polices.ToArray();
                }
            }
        }
    }
}
