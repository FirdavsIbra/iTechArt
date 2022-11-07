using iTechArt.Domain.Enums;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class StudentParsers : IStudentParsers
    {
        private readonly IStudentRepository _studentRepository;
        public StudentParsers(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Parse student's file from csv
        /// </summary>
        public Task CsvParseAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parse student's file from excel
        /// </summary>
        public async Task ExcelParseAsync(IFormFile file)
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
                    IList<StudentsDTO> students = new List<StudentsDTO>(rowCount - 1);

                    for (int row = 2; row <= rowCount; row++)
                    {
                        StudentsDTO student = new StudentsDTO
                        {
                            FirstName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            LastName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Password = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Majority = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Gender = Enum.Parse<Gender>(worksheet.Cells[row, 6].Value.ToString().Trim()),
                            DateOfBirth = DateOnly.Parse(worksheet.Cells[row, 7].Value.ToString().Trim()),
                            University = worksheet.Cells[row, 8].Value.ToString().Trim()
                        };
                        students.Add(student);
                    }
                    await _studentRepository.AddRangeAsync(students);
                }
            }
        }

        /// <summary>
        /// Parse student's file from xml
        /// </summary>
        public async Task XmlParseAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension == ".xml")
            {
                using var fileStream = new MemoryStream();

                await file.CopyToAsync(fileStream);

                fileStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                var nodes = xmlDocument.SelectNodes("/students/student");

                IList<StudentsDTO> students = new List<StudentsDTO>(nodes.Count);

                for (int node = 0; node < nodes.Count; node++)
                {
                    StudentsDTO student = new StudentsDTO
                    {
                        FirstName = nodes[node]["FirstName"].InnerText,
                        LastName = nodes[node]["LastName"].InnerText,
                        Email = nodes[node]["Email"].InnerText,
                        Password = nodes[node]["Password"].InnerText,
                        Majority = nodes[node]["Majority"].InnerText,
                        Gender = Enum.Parse<Gender>(nodes[node]["Gender"].InnerText),
                        DateOfBirth = DateOnly.Parse(nodes[node]["DateOfBirth"].InnerText),
                        University = nodes[node]["University"].InnerText
                    };
                    students.Add(student);
                }
                await _studentRepository.AddRangeAsync(students);
            }
        }
    }
}
