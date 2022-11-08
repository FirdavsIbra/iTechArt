using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class MedStaffParser : IMedStaffParser
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public MedStaffParser(IMedStaffRepository medStaffRepository)
        {
            _medStaffRepository = medStaffRepository;
        }

        /// <summary>
        /// Parse CSV file into MedStaff business model
        /// </summary>
        public async Task ParseCSVAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Equals(".csv"))
            {
                var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var csvLines = File.ReadAllLines(filePath);

                IList<IMedStaff> medStaffs = new List<IMedStaff>(csvLines.Length - 1);

                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');

                    MedStaffDTO medStaff = new MedStaffDTO()
                    {
                        FirstName = rowData[0].ToString().Trim(),
                        LastName = rowData[1].ToString().Trim(),
                        Gender = Enum.Parse<Gender>(rowData[2]),
                        Email = rowData[3].ToString().Trim(),
                        PhoneNumber = rowData[4].ToString().Trim(),
                        DateOfBirth = DateOnly.Parse(rowData[5]),
                        Address = rowData[6],
                        Salary = Decimal.Parse(rowData[7]),
                        HospitalName = rowData[8],
                        PostalCode = rowData[9] is null ? String.Empty : rowData[9],
                        Shift = Enum.Parse<Shift>(rowData[10])
                    };

                    medStaffs.Add(medStaff);
                }

                await _medStaffRepository.AddRangeAsync(medStaffs);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// Parse Excel file into MedStaff business model
        /// </summary>
        public async Task ParseExcelAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Equals(".xlsx") || fileExtension.Equals(".xls"))
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

                            IList<IMedStaff> medStaffs = new List<IMedStaff>(rowCount - 2);

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var medStaff = new MedStaffDTO()
                                {
                                    FirstName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                    LastName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                    Gender = Enum.Parse<Gender>(worksheet.Cells[row, 3].Value.ToString()),
                                    Email = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                    PhoneNumber = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                    DateOfBirth = DateOnly.Parse(worksheet.Cells[row, 6].Value.ToString()),
                                    Address = worksheet.Cells[row, 7].Value.ToString(),
                                    Salary = Convert.ToDecimal(worksheet.Cells[row, 8].Value),
                                    HospitalName = worksheet.Cells[row, 9].Value.ToString(),
                                    PostalCode = worksheet.Cells[row, 10].Value is null ? string.Empty : worksheet.Cells[row, 10].Value.ToString().Trim(),
                                    Shift = Enum.Parse<Shift>(worksheet.Cells[row, 11].Value.ToString())
                                };

                                medStaffs.Add(medStaff);
                            }

                            await _medStaffRepository.AddRangeAsync(medStaffs);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(nameof(ex));
                }
            }
        }
        
        /// <summary>
        /// Parse XML file into MedStaff business model
        /// </summary>
        public async Task ParseXMLAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Equals(".xml"))
            {
                var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);

                var nodes = xmlDocument.SelectNodes("/dataset/record");

                IList<IMedStaff> medStaffs = new List<IMedStaff>(nodes.Count);

                foreach (XmlNode node in nodes)
                {
                    MedStaffDTO medStaff = new MedStaffDTO
                    {
                        FirstName = node[nameof(medStaff.FirstName)].InnerText,
                        LastName = node[nameof(medStaff.LastName)].InnerText,
                        Gender = Enum.Parse<Gender>(node[nameof(medStaff.Gender)].InnerText),
                        Email = node[nameof(medStaff.Email)].InnerText,
                        PhoneNumber = node[nameof(medStaff.PhoneNumber)].InnerText,
                        DateOfBirth = DateOnly.Parse(node[nameof(medStaff.DateOfBirth)].InnerText),
                        Address = node[nameof(medStaff.Address)].InnerText,
                        Salary = Decimal.Parse(node[nameof(medStaff.Salary)].InnerText),
                        HospitalName = node[nameof(medStaff.HospitalName)].InnerText,
                        PostalCode = node[nameof(medStaff.PostalCode)]
                                            is null ? String.Empty 
                                                    : node[nameof(medStaff.PostalCode)].InnerText,
                        Shift = Enum.Parse<Shift>(node[nameof(medStaff.Shift)].InnerText)
                    };

                    medStaffs.Add(medStaff);
                }

                await _medStaffRepository.AddRangeAsync(medStaffs);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
