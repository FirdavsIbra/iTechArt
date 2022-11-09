using CsvHelper;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace iTechArt.Service.Parsers.PoliceParser
{
    public class CsvParser : ICsvParser
    {
        private readonly IPoliceRepository _policeRepository;

        public CsvParser(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }

        /// <summary>
        /// Parse CSV file and save to database
        /// </summary>
        public async Task ReadCSVAsync(IFormFile file)
        {
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                using(var sr = new StreamReader(fileStream))
                {
                    using(var csv = new CsvReader(sr, CultureInfo.InvariantCulture))

                    {
                        csv.Context.RegisterClassMap<PoliceMap>();
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        await _policeRepository.AddRangeAsync(records);
                    }
                }
            }
        }       
    }
}
