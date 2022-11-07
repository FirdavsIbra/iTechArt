using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels.HelperModels;
using iTechArt.Repository.Mappers;
using iTechArt.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Xml.Linq;

namespace iTechArt.Service.Parsers
{
    public sealed class GroceryParsers : IGroceryParsers
    {
        private static IList<IGrocery> _grocery = new List<IGrocery>();
        private readonly IGroceryRepository _groceryRepository;
        public GroceryParsers(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
        /// <summary>
        /// Parsing Csv format grocery files
        /// </summary>
        public async Task<ITaskResult> RecordCsvToDatabase(IFormFile formFile)
        {
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
                    var result = await _groceryRepository.AddGroceriesAsync(_grocery);

                    if (result.IsSuccess)
                    {
                        return new TaskResult
                        {
                            IsSuccess = true,
                            Message = JsonConvert.SerializeObject(_grocery, Newtonsoft.Json.Formatting.Indented)
                        };
                    }
                    return new TaskResult
                    {
                        IsSuccess = false,
                        Message = result.Exception.Message,
                    };
                }
            }
            catch (Exception ex)
            {

                return new TaskResult
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        /// <summary>
        /// Parsing Excel format grocery files
        /// </summary>
        public async Task<ITaskResult> RecordExcelToDatabase(IFormFile formFile)
        {
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
                        var result = await _groceryRepository.AddGroceriesAsync(_grocery);

                        if (result.IsSuccess)
                        {
                            return new TaskResult
                            {
                                IsSuccess = true,
                                Message = JsonConvert.SerializeObject(_grocery, Newtonsoft.Json.Formatting.Indented)
                            };
                        }
                        return new TaskResult
                        {
                            IsSuccess = false,
                            Message = result.Exception.Message,
                        };
                    }
                }
                catch (Exception ex)
                {

                    return new TaskResult
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
            }
            return new TaskResult
            {
                IsSuccess = false,
                Message = "File does not contain any lines",
            };
        }
        /// <summary>
        /// Parsing XML format grocery files
        /// </summary>
        public async Task<ITaskResult> RecordXmlToDatabase(IFormFile formFile)
        {
            XDocument xm = new XDocument();
            var reader = new StreamReader(formFile.OpenReadStream());
            var xdoc = XDocument.Load(reader);
            reader.ReadToEnd();
            try
            {
                var items = from item in xdoc.Descendants("dataset").Elements("record").AsEnumerable()
                            select new GroceryDTO
                            {
                                Id = Guid.Parse(item.Element("id").Value),
                                FirstName = item.Element("first_name").Value,
                                LastName = item.Element("last_name").Value,
                                Email = item.Element("email").Value,
                                Gender = (Gender)Enum.Parse(typeof(Gender), item.Element("gender").Value),
                                Birthday = (DateTime)item.Element("birthday"),
                                JobTitle = item.Element("Job_Title").Value,
                                DepartmentRetail = item.Element("department_retail").Value,
                                Salary = (double)item.Element("salary")

                            };

                List<IGrocery> groceryList = items.ToList<IGrocery>();
                var result = await _groceryRepository.AddGroceriesAsync(groceryList);
                if (result.IsSuccess)
                {
                    return new TaskResult
                    {
                        IsSuccess = true,
                        Message = JsonConvert.SerializeObject(groceryList, Newtonsoft.Json.Formatting.Indented)
                    };
                }
                return new TaskResult
                {
                    IsSuccess = false,
                    Message = result.Exception.Message,
                };
            }
            catch (Exception ex)
            {
                return new TaskResult
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
