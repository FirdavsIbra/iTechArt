using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.Repositories;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.IPoliceParsers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseCsv : ICsvParse
    {
        /// <summary>
        /// Parse CSV file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseCSVAsync(IFormFile file)
        {
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                using (var sr = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(sr, System.Globalization.CultureInfo.InvariantCulture))

                    {
                        csv.Context.RegisterClassMap<PoliceMap>();
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        return records;
                    }
                }
            }
        }
    }

    /// <summary>
    /// class for mapping police model for CSVReader.
    /// </summary>
    public class PoliceMap : ClassMap<PoliceDto>
    {
        public PoliceMap()
        {
            Map(c => c.Name).Name("Name");
            Map(c => c.Surname).Name("Surname");
            Map(c => c.Email).Name("Email");
            Map(c => c.Gender).Name("Gender");
            Map(c => c.Address).Name("Address");
            Map(c => c.JobTitle).Name("JobTitle");
            Map(c => c.Salary).Name("Salary");
        }
    }
}
