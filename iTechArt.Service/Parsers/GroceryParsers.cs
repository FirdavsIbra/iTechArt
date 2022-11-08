using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.Mappers;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Xml.Linq;

namespace iTechArt.Service.Parsers
{
    public sealed class GroceryParsers : IGroceryParsers
    {
        private static IList<IGrocery> _grocery;
        private readonly IGroceryRepository _groceryRepository;
        public GroceryParsers(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
        /// <summary>
        /// Parsing Csv format grocery files
        /// </summary>
        public async Task RecordCsvToDatabase(IFormFile formFile)
        {
            _grocery = new List<IGrocery>();
            try
            {
                using (var fileStream = formFile.OpenReadStream())
                using (var reader = new StreamReader(fileStream))
                {
                    string row;
                    bool initial = true;
                    while ((row = reader.ReadLine()) != null)
                    {
                        var items = row.Split(',');

                        if (initial)
                        {
                            initial = false;
                            continue;
                        }
                        try
                        {
                            _grocery.Add(GroceryMapper.CsvMapper(items));
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    await _groceryRepository.AddGroceriesAsync(_grocery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Parsing Excel format grocery files
        /// </summary>
        public async Task RecordExcelToDatabase(IFormFile formFile)
        {
            _grocery = new List<IGrocery>();
            if (formFile.Length > 0)
            {
                var s = formFile.OpenReadStream();
                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage(s))
                    {
                        var sheet = p.Workbook.Worksheets.First();
                        var count = sheet.Dimension.Rows;

                        for (int i = 2; i < count; i++)
                        {
                            _grocery.Add(GroceryMapper.XlsxMapper(sheet, i));

                        }
                         await _groceryRepository.AddGroceriesAsync(_grocery);
                    }
                }
                catch (Exception ex)
                {

                    throw ex; 
                }
            }
        }
        /// <summary>
        /// Parsing XML format grocery files
        /// </summary>
        public async Task RecordXmlToDatabase(IFormFile formFile)
        {
            _grocery = new List<IGrocery>();
            XDocument xm = new XDocument();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
            var xdoc = XDocument.Load(reader);
            reader.ReadToEnd();
                var items = from item in xdoc.Descendants("dataset").Elements("record")
                            select new GroceryDTO
                            {
                                FirstName = item.Element("first_name").Value,
                                LastName = item.Element("last_name").Value,
                                Email = item.Element("email").Value,
                                Gender = (Gender)Enum.Parse(typeof(Gender), item.Element("gender").Value),
                                Birthday = (DateTime)item.Element("birthday"),
                                JobTitle = item.Element("job_Title").Value,
                                DepartmentRetail = item.Element("department_retail").Value,
                                Salary = (double)item.Element("salary")
                            };

                _grocery = items.ToList<IGrocery>();
                await _groceryRepository.AddGroceriesAsync(_grocery);
            }
        }
    }
}
