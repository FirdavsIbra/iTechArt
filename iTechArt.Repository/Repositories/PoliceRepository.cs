using AutoMapper;
using CsvHelper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Police;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using iTechArt.Repository.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : IPoliceRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PoliceRepository(AppDbContext dbContext,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddUpdateAsync(IPolice entity)
        {
            PoliceDb police = _mapper.Map<PoliceDb>(entity);
            if (entity != null)
            {
                if (entity.Id > 0)
                {
                    _dbContext.Police.Update(police);
                }
                else
                {
                    _dbContext.Police.Add(police);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all Police data from database
        /// </summary>
        public async Task<IPolice[]> GetAllAsync()
        {
            // _dbContext.Police.Select(c => _mapper.Map<IPolice>(c));
            var policesDb = await _dbContext.Police.ToListAsync();
            List<Police> policeList = policesDb.Select(police => _mapper.Map<Police>(police)).ToList();

            return policeList.ToArray();
        }

        /// <summary>
        /// Get Police by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IPolice> GetByIdAsync(long id)
        {
            var entityFromDb = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == id);

            if (entityFromDb != null)
            {
                var ipolice = _mapper.Map<IPolice>(entityFromDb);
                return ipolice;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Police from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(long id)
        {
            var police = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == id);
            if (police != null)
            {
                _dbContext.Police.Remove(police);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        public int GetCountOfPolice()
        {
            return _dbContext.Police.Count();
        }

        /// <summary>
        /// Parse XLSX file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadExcelAsync(IFormFile file)
        {
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                using (var package = new ExcelPackage(fileStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            PoliceDb policeDb = new PoliceDb
                            {
                                Name = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Surname = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                Email = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                Gender = (Gender)Convert.ToByte(worksheet.Cells[row, 5].Value),
                                Address = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                JobTitle = worksheet.Cells[row, 7].Value.ToString().Trim(),
                                Salary = Convert.ToDouble(worksheet.Cells[row, 8].Value)
                            };
                            _dbContext.Police.Add(policeDb);
                            await _dbContext.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Parse XML file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadXMLAsync(IFormFile file)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "temp", file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
            {
                try
                {
                    PoliceDb policeDb = new PoliceDb
                    {
                        Name = node["Name"].InnerText,
                        Surname = node["Surname"].InnerText,
                        Email = node["Email"].InnerText,
                        Gender = (Gender)Enum.Parse(typeof(Gender), node["Gender"].InnerText),
                        Address = node["Address"].InnerText,
                        JobTitle = node["JobTitle"].InnerText,
                        Salary = Convert.ToDouble(node["Salary"].InnerText)
                    };

                    //_dbContext.Police.Add(policeDb);
                    //await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            // Delete the created file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        /// <summary>
        /// Parse CSV file and save to database
        /// </summary>
        /// <param name="file"></param>
        public async Task ReadCSVAsync(IFormFile file)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "temp", file.FileName);
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
                        var records = csv.GetRecords<PoliceDto>();
                        foreach (var record in records)
                        {
                            PoliceDb policeDb = new PoliceDb
                            {
                                Name = record.Name.ToString(),
                                Surname = record.Surname.ToString(),
                                Email = record.Email.ToString(),
                                Gender = (Gender)Enum.Parse(typeof(Gender), record.Gender.ToString()),
                                Address = record.Address.ToString(),
                                JobTitle = record.JobTitle.ToString(),
                                Salary = Convert.ToDouble(record.Salary)
                            };
                            await _dbContext.Police.AddAsync(policeDb);
                            await _dbContext.SaveChangesAsync();
                            //var x = await _dbContext.Police.FirstOrDefaultAsync(c => c.Name == "Maybelle");
                            //if(x != null) Console.WriteLine(x.Address);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
            // Delete the created file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        ///// <summary>
        ///// Update entity
        ///// </summary>
        ///// <param name="entity"></param>
        //public async Task UpdateAsync(IPolice entity)
        //{
        //    var entry = _dbContext.Set<PoliceDb>().Update(_mapper.Map<PoliceDb>(entity));

        //    await _dbContext.SaveChangesAsync();
        //}
    }
}