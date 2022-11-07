using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.Constants;
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
                        csv.Context.RegisterClassMap<PupilMap>();
                        var records = csv.GetRecords<PupilForCreationDto>();
 
                        foreach (var record in records)
                        {
                            PupilForCreationDto pupil = new PupilForCreationDto
                            {
                                FirstName = record.FirstName.ToString().Trim(),
                                LastName = record.LastName.ToString().Trim(),
                                DateOfBirth = DateOnly.Parse(record.DateOfBirth.ToString().Trim()),
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
                            FirstName = worksheet.Cells[row, PupilIndexConstants.FIRSTNAME].Value.ToString().Trim(),
                            LastName = worksheet.Cells[row, PupilIndexConstants.LASTNAME].Value.ToString().Trim(),
                            DateOfBirth = DateOnly.Parse(worksheet.Cells[row, PupilIndexConstants.DATEOFBIRTH].Value.ToString().Trim()),
                            Gender = Enum.Parse<Gender>(worksheet.Cells[row, PupilIndexConstants.GENDER].Value.ToString().Trim()),
                            PhoneNumber = worksheet.Cells[row, PupilIndexConstants.PHONENUMBER].Value.ToString().Trim(),
                            Address = worksheet.Cells[row, PupilIndexConstants.ADDRESS].Value.ToString().Trim(),
                            City = worksheet.Cells[row, PupilIndexConstants.CITY].Value.ToString().Trim(),
                            SchoolName = worksheet.Cells[row, PupilIndexConstants.SCHOOLNAME].Value.ToString().Trim(),
                            Grade = Convert.ToByte(worksheet.Cells[row, PupilIndexConstants.GRADE].Value),
                            CourseLanguage = Enum.Parse<CourseLanguage>(worksheet.Cells[row, PupilIndexConstants.COURSELANGUAGE].Value.ToString().Trim()),
                            Shift = Enum.Parse<Shift>(worksheet.Cells[row, PupilIndexConstants.SHIFT].Value.ToString().Trim())
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

                fileStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                var nodes = xmlDocument.SelectNodes("/pupils/pupil");

                IList<PupilForCreationDto> pupils = new List<PupilForCreationDto>(nodes.Count);

                for (int node = 0; node < nodes.Count; node++)
                {
                    PupilForCreationDto pupil = new PupilForCreationDto
                    {
                        FirstName = nodes[node]["FirstName"].InnerText,
                        LastName = nodes[node]["LastName"].InnerText,
                        DateOfBirth = DateOnly.Parse(nodes[node]["DateOfBirth"].InnerText),
                        Gender = Enum.Parse<Gender>(nodes[node]["Gender"].InnerText),
                        PhoneNumber = nodes[node]["PhoneNumber"].InnerText,
                        Address = nodes[node]["Address"].InnerText,
                        City = nodes[node]["City"].InnerText,
                        SchoolName = nodes[node]["SchoolName"].InnerText,
                        Grade = Convert.ToByte(nodes[node]["Grade"].InnerText),
                        CourseLanguage = Enum.Parse<CourseLanguage>(nodes[node]["CourseLanguage"].InnerText),
                        Shift = Enum.Parse<Shift>(nodes[node]["Shift"].InnerText)
                    };
                    pupils.Add(pupil);
                }
                await _pupilRepository.AddRangeAsync(pupils);
            }
        }
    }

    internal sealed class PupilMap : ClassMap<PupilForCreationDto>
    {
        public PupilMap()
        {
            Map(p => p.FirstName).Name("FirstName");
            Map(p => p.LastName).Name("LastName");
            Map(p => p.DateOfBirth).Name("DateOfBirth");
            Map(p => p.Gender).Name("Gender");
            Map(p => p.PhoneNumber).Name("PhoneNumber");
            Map(p => p.Address).Name("Address");
            Map(p => p.City).Name("City");
            Map(p => p.SchoolName).Name("SchoolName");
            Map(p => p.Grade).Name("Grade");
            Map(p => p.CourseLanguage).Name("CourseLanguage");
            Map(p => p.Shift).Name("Shift");
        }
    }
}
