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
using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using System.Xml;
using iTechArt.Service.Helpers;

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
        public async Task<IStudent[]> ExportStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
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
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(formFile.FileName);
                XmlNodeList nodes = xmlDocument.DocumentElement.SelectNodes("/dataset/record");

                foreach (XmlNode node in nodes)
                {
                    StudentsDTO studentsDTO = new StudentsDTO()
                    {
                        FirstName = node["FirstName"].InnerText,
                        LastName = node["LastName"].InnerText,
                        Email = node["Email"].InnerText,
                        Password = node["Password"].InnerText,
                        Majority = node["Majority"].InnerText,
                        Gender = (Domain.Enums.Gender)byte.Parse(node["Gender"].InnerText),
                        DateOfBirth = DateTime.ParseExact(node["DateOfBirth"].InnerText, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        University = node["University"].InnerText
                    };
                    await _studentRepository.AddAsync(studentsDTO);
                }
                
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
                foreach (var line in lines.Skip(1))
                {
                    string[] fields = line.Split(",");

                    var obj = new StudentsDTO();
                    // parse Id
                    obj.FirstName = fields[0];
                    obj.LastName = fields[1];
                    // parse Gender
                    if (byte.TryParse(fields[5], out var parsedGender))
                    {
                        obj.Gender = (Domain.Enums.Gender)parsedGender;
                    }
                    // parse birthday
                    try
                    {
                        obj.DateOfBirth = DateTime.ParseExact(fields[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {

                        throw new Exception(e.Message);
                    }
                    // parse email
                    obj.Email = fields[2];
                    // parse password
                    obj.Password = fields[3];
                    // parse university
                    obj.University = fields[7];
                    // parse majority
                    obj.Majority = fields[4];
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
