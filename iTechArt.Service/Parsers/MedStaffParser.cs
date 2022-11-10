using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class MedStaffParser : IMedStaffParser
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public MedStaffParser(IMedStaffRepository medStaffRepository)
        {
            _medStaffRepository = medStaffRepository;
        }

        /// <summary>
        /// Parse CSV file into MedStaff business model.
        /// </summary>
        public async Task ParseCSVAsync(IFormFile file)
        {
            //using var fileStream = new MemoryStream();

            //await file.CopyToAsync(fileStream);

            //fileStream.Position = 0;

            //using var csvReader = new StreamReader(fileStream);

            //using CsvReader csv = new CsvReader(csvReader, CultureInfo.InvariantCulture);

            //csv.Context.RegisterClassMap<MedStaffMap>();

            //var results = csv.GetRecords<MedStaffDTO>();

            //await _medStaffRepository.AddRangeAsync(results);

            var filePath = Path.Combine(EnvironmentHelper.AttachmentPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var csvLines = File.ReadAllLines(filePath);

            IList<IMedStaff> medStaffs = new List<IMedStaff>(csvLines.Length - 1);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');

                MedStaffDTO medStaff = new MedStaffDTO()
                {
                    FirstName = rowData[0].ToString().Trim(),
                    LastName = rowData[1].ToString().Trim(),
                    Gender = Enum.Parse<Gender>(rowData[2]),
                    Email = rowData[3].ToString().Trim(),
                    PhoneNumber = rowData[4].ToString().Trim(),
                    DateOfBirth = DateOnly.Parse(rowData[5]),
                    Address = rowData[6],
                    Salary = Decimal.Parse(rowData[7]),
                    HospitalName = rowData[8],
                    PostalCode = rowData[9] is null ? String.Empty : rowData[9],
                    Shift = Enum.Parse<Shift>(rowData[10])
                };

                medStaffs.Add(medStaff);
            }

            await _medStaffRepository.AddRangeAsync(medStaffs);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Parse Excel file into MedStaff business model.
        /// </summary>
        public async Task ParseExcelAsync(IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            using var package = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            IList<IMedStaff> medStaffs = new List<IMedStaff>(rowCount - 2);

            for (int row = 2; row <= rowCount; row++)
            {
                var medStaff = new MedStaffDTO()
                {
                    FirstName = worksheet.Cells[row, MedStaffIndexConstants.FIRSTNAMEn].Value.ToString().Trim(),
                    LastName = worksheet.Cells[row, MedStaffIndexConstants.LASTNAMEn].Value.ToString().Trim(),
                    Gender = Enum.Parse<Gender>(worksheet.Cells[row, MedStaffIndexConstants.GENDERn].Value.ToString()),
                    Email = worksheet.Cells[row, MedStaffIndexConstants.EMAILn].Value.ToString().Trim(),
                    PhoneNumber = worksheet.Cells[row, MedStaffIndexConstants.PHONENUMBERn].Value.ToString().Trim(),
                    DateOfBirth = DateOnly.Parse(worksheet.Cells[row, MedStaffIndexConstants.DATEOFBIRTHn].Value.ToString()),
                    Address = worksheet.Cells[row, MedStaffIndexConstants.ADDRESSn].Value.ToString(),
                    Salary = Convert.ToDecimal(worksheet.Cells[row, MedStaffIndexConstants.SALARYn].Value),
                    HospitalName = worksheet.Cells[row, MedStaffIndexConstants.HOSPITALNAMEn].Value.ToString(),
                    PostalCode = worksheet.Cells[row, MedStaffIndexConstants.POSTALCODEn].Value is null 
                            ? string.Empty : worksheet.Cells[row, MedStaffIndexConstants.POSTALCODEn].Value.ToString().Trim(),
                    Shift = Enum.Parse<Shift>(worksheet.Cells[row, MedStaffIndexConstants.SHIFTn].Value.ToString())
                };

                medStaffs.Add(medStaff);
            }

            await _medStaffRepository.AddRangeAsync(medStaffs);
        }
        
        /// <summary>
        /// Parse XML file into MedStaff business model.
        /// </summary>
        public async Task ParseXMLAsync(IFormFile file)
        {
            using var fileStream = new MemoryStream();
            await file.CopyToAsync(fileStream);

            fileStream.Position = 0;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileStream);

            var nodes = xmlDocument.SelectNodes(MedStaffIndexConstants.XPATH);

            IList<MedStaffDTO> medStaffDTOs = new List<MedStaffDTO>(nodes.Count);

            for(int node = 0; node < nodes.Count; node++)
            {
                MedStaffDTO medStaff = new MedStaffDTO
                {
                    FirstName = nodes[node][MedStaffIndexConstants.FIRSTNAME].InnerText,
                    LastName = nodes[node][MedStaffIndexConstants.LASTNAME].InnerText,
                    Gender = Enum.Parse<Gender>(nodes[node][MedStaffIndexConstants.GENDER].InnerText),
                    Email = nodes[node][MedStaffIndexConstants.EMAIL].InnerText,
                    PhoneNumber = nodes[node][MedStaffIndexConstants.PHONENUMBER].InnerText,
                    DateOfBirth = DateOnly.Parse(nodes[node][MedStaffIndexConstants.DATEOFBIRTH].InnerText),
                    Address = nodes[node][MedStaffIndexConstants.ADDRESS].InnerText,
                    Salary = Decimal.Parse(nodes[node][MedStaffIndexConstants.SALARY].InnerText),
                    HospitalName = nodes[node][MedStaffIndexConstants.HOSPITALNAME].InnerText,
                    PostalCode = nodes[node][MedStaffIndexConstants.POSTALCODE] is null? String.Empty
                            : nodes[node][MedStaffIndexConstants.POSTALCODE].InnerText,
                    Shift = Enum.Parse<Shift>(nodes[node][MedStaffIndexConstants.SHIFT].InnerText),
                };

                medStaffDTOs.Add(medStaff);
            }

            await _medStaffRepository.AddRangeAsync(medStaffDTOs);
        }
    }

    public sealed class MedStaffMap: ClassMap<MedStaffDTO>
    {
        public MedStaffMap()
        {
            Map(m => m.FirstName).Name(MedStaffIndexConstants.FIRSTNAME);
            Map(m => m.LastName).Name(MedStaffIndexConstants.LASTNAME);
            Map(m => m.Gender).Name(MedStaffIndexConstants.GENDER);
            Map(m => m.Email).Name(MedStaffIndexConstants.EMAIL);
            Map(m => m.PhoneNumber).Name(MedStaffIndexConstants.PHONENUMBER);
            Map(m => m.DateOfBirth).Name(MedStaffIndexConstants.DATEOFBIRTH);
            Map(m => m.Address).Name(MedStaffIndexConstants.ADDRESS);
            Map(m => m.Salary).Name(MedStaffIndexConstants.SALARY);
            Map(m => m.HospitalName).Name(MedStaffIndexConstants.HOSPITALNAME);
            Map(m => m.PostalCode).Name(MedStaffIndexConstants.POSTALCODE);
            Map(m => m.Shift).Name(MedStaffIndexConstants.SHIFT);
        }
    }
}
