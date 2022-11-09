using ExcelLibrary.SpreadSheet;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
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
                fileStream.Position = 0;

                if (fileExtension == FileExtensions.xlsx)
                {
                    using (var package = new ExcelPackage(fileStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = Nums.Two; row <= rowCount; row++)
                        {
                            var policeDto = new PoliceDto
                            {
                                Name = worksheet.GetValue<string>(row, Nums.One).Trim(),
                                Surname = worksheet.GetValue<string>(row, Nums.Two).Trim(),
                                Email = worksheet.GetValue<string>(row, Nums.Three).Trim(),
                                Gender = Enum.Parse<Gender>(worksheet.GetValue<string>(row, Nums.Four)),
                                Address = worksheet.GetValue<string>(row, Nums.Five).Trim(),
                                JobTitle = worksheet.GetValue<string>(row, Nums.Six).Trim(),
                                Salary = Convert.ToDouble(worksheet.Cells[row, Nums.Seven].Value)
                            };
                            polices.Add(policeDto);
                        }
                    }
                }
                // for type XLS.
                else
                {
                    var workBook = Workbook.Load(fileStream);
                    var workSheet = workBook.Worksheets[0];
                    var cells = workSheet.Cells;
                    var rowCount = cells.Rows.Count;
                    
                    for(int rowIndex = Nums.One; rowIndex < rowCount; rowIndex++)
                    {
                        var policeDto = new PoliceDto
                        {
                            Name = cells[rowIndex, Nums.Zero].Value.ToString().Trim(),
                            Surname = cells[rowIndex, Nums.One].Value.ToString().Trim(),
                            Email = cells[rowIndex, Nums.Two].Value.ToString().Trim(),
                            Gender = Enum.Parse<Gender>(cells[rowIndex, Nums.Three].Value.ToString()),
                            Address = cells[rowIndex, Nums.Four].Value.ToString().Trim(),
                            JobTitle = cells[rowIndex, Nums.Five].Value.ToString().Trim(),
                            Salary = Convert.ToDouble(cells[rowIndex, Nums.Six].Value)
                        };
                        polices.Add(policeDto);
                    }
                }
            }
            return polices.ToArray();
        }
    }
}
