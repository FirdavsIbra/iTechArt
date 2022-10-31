using CsvHelper.Configuration;
using CsvHelper;
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
            else if (fileExtension == ".csv")
            {
                await CsvParser(file);
            }
            else if (fileExtension == ".xml")
            {
                await XmlParser(file);
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

        private async Task CsvParser(IFormFile file)
        {
            var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var csvLines = File.ReadAllLines(filePath);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');

                MedStaffDTO medStaff = new MedStaffDTO()
                {
                    FirstName = rowData[0].ToString().Trim(),
                    LastName = rowData[1].ToString().Trim(),
                    Gender = (Gender)Convert.ToByte(rowData[2]),
                    Email = rowData[3].ToString().Trim(),
                    PhoneNumber = rowData[4].ToString().Trim(),
                    DateOfBirth = Convert.ToDateTime(rowData[5]),
                    Address = rowData[6],
                    Salary = Convert.ToDecimal(rowData[7]),
                    HospitalName = rowData[8],
                    PostalCode = rowData[9] is null? String.Empty: rowData[9],
                    Shift = (Shift)Convert.ToByte(rowData[10])
                };

                await _medStaffRepository.AddAsync(medStaff);
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private async Task XmlParser(IFormFile file)
        {
            var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            
            foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
            {
                MedStaffDTO medStaff = new MedStaffDTO
                {
                    FirstName = node["FirstName"].InnerText,
                    LastName = node["LastName"].InnerText,
                    Gender = (Gender)Convert.ToByte(node["Gender"].InnerText),
                    Email = node["Email"].InnerText,
                    PhoneNumber = node["PhoneNumber"].InnerText,
                    DateOfBirth = Convert.ToDateTime(node["DateOfBirth"].InnerText),
                    Address = node["Address"].InnerText,
                    Salary = Convert.ToDecimal(node["Salary"].InnerText),
                    HospitalName = node["HospitalName"].InnerText,
                    PostalCode = node["PostalCode"] is null? String.Empty: node["PostalCode"].InnerText,
                    Shift = (Shift)Convert.ToByte(node["Shift"].InnerText)
                };

                await _medStaffRepository.AddAsync(medStaff);
            }
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
