using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System;
using System.Globalization;

namespace iTechArt.Service.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Async method takes no parameters and returns serialized entities as file
        /// </summary>
        public async Task<IStudents[]> ExportStudentsAsync()
        {
            return await _studentRepository.GetAll();
        }

        /// <summary>
        /// Async method that saves entities into DB
        /// </summary>
        public async Task ImportStudentsAsync(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);

            if (fileExtension == ".xlsx")
            {
                await ExcelImporter(formFile);
            }
            else if (fileExtension == ".csv")
            {
                await CsvImporter(formFile);
            }
            else if (fileExtension == ".xml")
            {
                await XmlImporter(formFile);
            }
            else
            {
                throw new Exception("wrong file extention");
            }
        }

        private async Task XmlImporter(IFormFile formFile)
        {
            try
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(StudentsDTO));
                var streamReader = new StreamReader(formFile.OpenReadStream());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task CsvImporter(IFormFile formFile)
        {
            using (var parser = new TextFieldParser(formFile.OpenReadStream()))
            {
                var lines = new List<string>();
                while (!parser.EndOfData)
                {
                    //Processing row
                    lines.Add(parser.ReadLine());
                }
                foreach (var line in lines)
                {
                    string[] fields = line.Split(",");

                    var obj = new StudentsDTO();
                    // parse Id
                    if (long.TryParse(fields[0], out var parsedId))
                    {
                        obj.Id = parsedId;
                    }
                    obj.FirstName = fields[1];
                    obj.LastName = fields[2];
                    // parse Gender
                    if (byte.TryParse(fields[3], out var parsedGender))
                    {
                        obj.Gender = (Domain.Enums.Gender)parsedGender;
                    }
                    // parse birthday
                    try
                    {
                        obj.DateOfBirth = DateTime.ParseExact(fields[4], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {

                        throw new Exception("bad date format");
                    }
                    // parse email
                    obj.Email = fields[5];
                    // parse password
                    obj.Password = fields[6];
                    // parse university
                    obj.University = fields[7];
                    // parse majority
                    obj.Majority = fields[8];
                    await _studentRepository.AddAsync(obj);
                }
            }
        }

        private async Task ExcelImporter(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
