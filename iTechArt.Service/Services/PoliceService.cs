using CsvHelper;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class PoliceService : IPoliceService
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PoliceService(IPoliceRepository policeRepository,
                             IWebHostEnvironment webHostEnvironment)
        {
            _policeRepository = policeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Export data from the databse
        /// </summary>
        public async Task<IPolice[]> ExportPoliceData()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Import data to the database
        /// </summary>
        public async Task ImportPoliceData(IFormFile formFile)
        {
            string fileExtension = Path.GetExtension(formFile.FileName);

            // .xlsx type
            if (fileExtension == FileConstants.Extensions[0] || FileConstants.EXCEL.Contains(formFile.ContentType))
            {
                await ReadExcelAsync(formFile);
            }
            // .csv type
            else if (fileExtension == FileConstants.Extensions[2] || FileConstants.CSV.Contains(formFile.ContentType))
            {
                await ReadCSVAsync(formFile);
            }
            // .xml type
            else if (fileExtension == FileConstants.Extensions[3] || FileConstants.XML.Contains(formFile.ContentType))
            {
                await ReadXMLAsync(formFile);
            }
        }


        /// <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        public async Task AddUpdatePolice(IPolice police)
        {
            await _policeRepository.AddAsync(police);
        }

        /// <summary>
        /// Get all Police entities from database
        /// </summary>
        public async Task<IPolice[]> GetAllPolice()
        {
            return await _policeRepository.GetAllAsync();
        }

        /// <summary>
        /// Delete Police entity from database
        /// </summary>
        public async Task DeletePolice(long id)
        {
            await _policeRepository.DeleteAsync(id);
        }


        /// <summary>
        /// Parse XLSX file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadExcelAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();

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
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                    await _policeRepository.AddRangeAsync(polices);
                }
            }
        }


        /// <summary>
        /// Parse XML file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadXMLAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
            {
                try
                {
                    PoliceDto policeDb = new PoliceDto
                    {
                        Name = node["Name"].InnerText,
                        Surname = node["Surname"].InnerText,
                        Email = node["Email"].InnerText,
                        Gender = (Gender)Convert.ToByte(node["Gender"].InnerText),
                        Address = node["Address"].InnerText,
                        JobTitle = node["JobTitle"].InnerText,
                        Salary = Convert.ToDouble(node["Salary"].InnerText)
                    };
                    polices.Add(policeDb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            await _policeRepository.AddRangeAsync(polices);
            DeleteFile(filePath);
        }


        /// <summary>
        /// Parse CSV file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadCSVAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            using (TextReader csvReader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        foreach (var record in records)
                        {
                            PoliceDto policeDto = new PoliceDto
                            {
                                Name = record.Name.ToString().Trim(),
                                Surname = record.Surname.ToString().Trim(),
                                Email = record.Email.ToString().Trim(),
                                Gender = (Gender)Convert.ToByte(record.Gender),
                                Address = record.Address.ToString().Trim(),
                                JobTitle = record.JobTitle.ToString().Trim(),
                                Salary = Convert.ToDouble(record.Salary)
                            };
                            polices.Add(policeDto);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
            await _policeRepository.AddRangeAsync(polices);
            DeleteFile(filePath);
        }

        /// <summary>
        /// Delete an existing file using filepath
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}