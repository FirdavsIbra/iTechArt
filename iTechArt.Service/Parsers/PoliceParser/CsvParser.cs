using AutoMapper;
using CsvHelper;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace iTechArt.Service.Parsers.PoliceParser
{
    public class CsvParser : ICsvParser
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CsvParser(IPoliceRepository policeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _policeRepository = policeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Parse CSV file and save to database
        /// </summary>
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
                        csv.Context.RegisterClassMap<PoliceMap>();
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        foreach (var record in records)
                        {
                            var policeDto = new PoliceDto
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
                        Console.WriteLine("Exception occured with a message: " + ex.Message.ToString());
                    }
                }
            }
            await _policeRepository.AddRangeAsync(polices.ToArray());

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }       
    }
}
