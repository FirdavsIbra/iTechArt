using CsvHelper;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class PupilParsers : IPupilParsers
    {
        private readonly IPupilRepository _pupilRepository;
        public PupilParsers(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }

        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        public async Task CsvParser(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".csv")
            {
                IList<PupilForCreationDto> pupils = new List<PupilForCreationDto>();

                using var fileStream = new MemoryStream();

                await file.CopyToAsync(fileStream);

                using (StreamReader csvReader = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<PupilForCreationDto>();
                        foreach (var record in records)
                        {
                            PupilForCreationDto pupil = new PupilForCreationDto
                            {
                                FirstName = record.FirstName.ToString().Trim(),
                                LastName = record.LastName.ToString().Trim(),
                                DateOfBirth = Convert.ToDateTime(record.DateOfBirth.ToString().Trim()),
                                Gender = Enum.Parse<Gender>(record.Gender.ToString().Trim()),
                                PhoneNumber = record.PhoneNumber.ToString().Trim(),
                                Address = record.Address.ToString().Trim(),
                                City = record.City.ToString().Trim(),
                                SchoolName = record.SchoolName.ToString().Trim(),
                                Grade = Byte.Parse(record.Grade.ToString().Trim()),
                                CourseLanguage = Enum.Parse<CourseLanguage>(record.CourseLanguage.ToString().Trim()),
                                Shift = Enum.Parse<Shift>(record.Shift.ToString().Trim())
                            };
                            pupils.Add(pupil);
                        }
                    }
                }
                await _pupilRepository.AddRangeAsync(pupils);
            }
        }

        /// <summary>
        /// Parse pupil's file from excel
        /// </summary>
        public async Task ExcelParser(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xlsx" || fileExtension == ".xls")
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using var package = new ExcelPackage(stream);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    IList<PupilForCreationDto> pupils = new List<PupilForCreationDto>(rowCount - 1);

                    for (int row = 2; row <= rowCount; row++)
                    {
                        PupilForCreationDto pupil = new PupilForCreationDto
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
                            Shift = (Shift)Convert.ToByte(worksheet.Cells[row, 11].Value)
                        };
                        pupils.Add(pupil);
                    }
                    await _pupilRepository.AddRangeAsync(pupils);
                }
            }
        }

        /// <summary>
        /// Parse pupil's file from xml
        /// </summary>
        public async Task XmlParser(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension == ".xml")
            {
                using var fileStream = new MemoryStream();

                await file.CopyToAsync(fileStream);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                var nodes = xmlDocument.SelectNodes("/pupils/pupil");

                IList<PupilForCreationDto> pupils = new List<PupilForCreationDto>(nodes.Count);

                for (int i = 0; i < nodes.Count; i++)
                {
                    PupilForCreationDto pupil = new PupilForCreationDto
                    {
                        FirstName = nodes[i]["FirstName"].InnerText,
                        LastName = nodes[i]["LastName"].InnerText,
                        DateOfBirth = Convert.ToDateTime(nodes[i]["DateOfBirth"].InnerText),
                        Gender = Enum.Parse<Gender>(nodes[i]["Gender"].InnerText),
                        PhoneNumber = nodes[i]["PhoneNumber"].InnerText,
                        Address = nodes[i]["Address"].InnerText,
                        City = nodes[i]["City"].InnerText,
                        SchoolName = nodes[i]["SchoolName"].InnerText,
                        Grade = Convert.ToByte(nodes[i]["Grade"].InnerText),
                        CourseLanguage = Enum.Parse<CourseLanguage>(nodes[i]["CourseLanguage"].InnerText),
                        Shift = Enum.Parse<Shift>(nodes[i]["Shift"].InnerText)
                    };
                    pupils.Add(pupil);
                }
                await _pupilRepository.AddRangeAsync(pupils);
            }
            
        }
    }
}
