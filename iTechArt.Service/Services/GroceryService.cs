using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.BusinessModels.HelperModels;
using iTechArt.Repository.Mappers;
using iTechArt.Service.DTOs;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Xml.Linq;

namespace iTechArt.Serivce.Services
{
    public class GroceryService : IGroceryService
    {
        private static List<IGrocery> _grocery = new List<IGrocery>();
        private readonly IGroceryRepository _groceryRepository;
        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        /// <summary>
        /// Export grocery data
        /// </summary>
        public Task<IGrocery[]> ExportGrocery()
        {
            return _groceryRepository.GetAll();
        }

        /// <summary>
        /// Import grocery data
        /// </summary>
        public Task ImportGrocery()
        {
            return _groceryRepository.GetAll();
        }
        /// <summary>
        /// No implementation yet
        /// </summary>
        public int GetCountOfGrocery()
        {
            return _groceryRepository.GetCountOfGrocery();
        }
        /// <summary>
        /// Parse the csv data to businessModel to record to db
        /// </summary>
        public async Task<IServiceResult> RecordCsvToDatabase(IFormFile formFile)
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
                        return new ServiceResult
                        {
                            IsSuccess = true,
                            Message = JsonConvert.SerializeObject(_grocery, Newtonsoft.Json.Formatting.Indented)
                        };
                    }
                    return new ServiceResult
                    {
                        IsSuccess = false,
                        Message = result.Exception.Message,
                    };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        /// <summary>
        /// Parse the xlsx data to businessModel to record to db
        /// </summary>
        public async Task<IServiceResult> RecordXlsxToDatabase(IFormFile formFile)
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
                            return new ServiceResult
                            {
                                IsSuccess = true,
                                Message = JsonConvert.SerializeObject(_grocery, Newtonsoft.Json.Formatting.Indented)
                            };
                        }
                        return new ServiceResult
                        {
                            IsSuccess = false,
                            Message = result.Exception.Message,
                        };
                    }
                }
                catch (Exception ex)
                {

                    return new ServiceResult
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
            }
            return new ServiceResult
            {
                IsSuccess = false,
                Message = "File does not contain any lines",
            };
        }
        /// <summary>
        /// Parse the xml data to businessModel to record to db
        /// </summary>
        public async Task<IServiceResult> RecordXmlToDatabase(IFormFile formFile)
        {
            XDocument xm = new XDocument();
            var reader = new StreamReader(formFile.OpenReadStream());
            var xdoc = XDocument.Load(reader);
            reader.ReadToEnd();
                var items = from item in xdoc.Descendants("dataset").Elements("record").AsEnumerable()
                            select new GroceryDTO
                            {
                                Id = Guid.Parse(item.Element("id").Value),
                                FirstName = item.Element("first_name").Value,
                                LastName = item.Element("last_name").Value,
                                Email = item.Element("email").Value,
                                Gender = (Gender)Enum.Parse(typeof(Gender),item.Element("gender").Value),
                                Birthday = (DateTime)item.Element("birthday"),
                                JobTitle = item.Element("Job_Title").Value,
                                DepartmentRetail = item.Element("department_retail").Value,
                                Salary = (double)item.Element("salary")

                            };

            List<IGrocery> groceryList = items.ToList<IGrocery>();
            await _groceryRepository.AddGroceriesAsync(groceryList); 
            return null;
        }
    }
}
