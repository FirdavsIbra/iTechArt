using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using ITechArt.Parsers.Constants;
using ITechArt.Parsers.Dtos;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace ITechArt.Parsers.Parsers
{
    public sealed class PupilParser : IPupilParser
    {
        /// <summary>
        /// Parse pupil's file from csv
        /// </summary>
        public async Task<IPupil[]> CsvParseAsync(IFormFile file)
        {
            using var fileStream = new MemoryStream();

            await file.CopyToAsync(fileStream);
            fileStream.Position = 0;

            using TextReader csvReader = new StreamReader(fileStream);
            using var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<PupilMap>();
            var records = csv.GetRecords<PupilDto>();

            return records.ToArray();
        }

        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public async Task<IPupil[]> ExcelParseAsync(IFormFile file)
        {
            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);
            using var package = new ExcelPackage(stream);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;
            IList<PupilDto> pupils = new List<PupilDto>(rowCount - 1);

            for (int row = 2; row <= rowCount; row++)
            {
                PupilDto pupil = new()
                {
                    FirstName = worksheet.GetValue<string>(row, PupilConstants.FIRSTNAME).Trim(),
                    LastName = worksheet.GetValue<string>(row, PupilConstants.LASTNAME).Trim(),
                    DateOfBirth = DateOnly.Parse(worksheet.GetValue<string>(row, PupilConstants.DATEOFBIRTH).Trim()),
                    Gender = Enum.Parse<Gender>(worksheet.GetValue<string>(row, PupilConstants.GENDER).Trim()),
                    PhoneNumber = worksheet.GetValue<string>(row, PupilConstants.PHONENUMBER).Trim(),
                    Address = worksheet.GetValue<string>(row, PupilConstants.ADDRESS).Trim(),
                    City = worksheet.GetValue<string>(row, PupilConstants.CITY).Trim(),
                    SchoolName = worksheet.GetValue<string>(row, PupilConstants.SCHOOLNAME).Trim(),
                    Grade = Convert.ToInt32(worksheet.GetValue<int>(row, PupilConstants.GRADE)),
                    CourseLanguage = Enum.Parse<CourseLanguage>(worksheet.GetValue<string>(row, PupilConstants.COURSELANGUAGE).Trim()),
                    Shift = Enum.Parse<Shift>(worksheet.GetValue<string>(row, PupilConstants.SHIFT).Trim())
                };
                pupils.Add(pupil);
            }
            return pupils.ToArray();
        }

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public async Task<IPupil[]> XmlParseAsync(IFormFile file)
        {
            using var fileStream = new MemoryStream();

            await file.CopyToAsync(fileStream);

            fileStream.Position = 0;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileStream);

            var nodes = xmlDocument.SelectNodes("/pupils/pupil");

            IList<PupilDto> pupils = new List<PupilDto>(nodes.Count);

            for (int node = 0; node < nodes.Count; node++)
            {
                PupilDto pupil = new PupilDto
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
            return pupils.ToArray();
        }
    }

    public sealed class PupilMap : ClassMap<PupilDto>
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
