using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using OfficeOpenXml;
using System.Globalization;

namespace iTechArt.Repository.Mappers
{
    public static class GroceryMapper
    {
        private const string DATETIMEFORMAT = "MM/dd/yyyy";
        private const string INVALID_DOUBLE_MESSAGE = "Could not conver string to double: ";
        private const string INVALID_DATETIME_MESSAGE = "Could not convert string to DateTime: ";
        private const string INVALID_ENUM_MESSAGE = "Could not convert string to Enum: ";

        /// <summary>
        /// Checking the coming input for parsing from string to double and returning the result if its parsed
        /// </summary>
        private static double DoubleGuard(string input) 
        {
            double doubleOutput;
            var result = double.TryParse(input, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out doubleOutput);
            if (result)
                return doubleOutput;
            throw new InvalidDataException($"{INVALID_DOUBLE_MESSAGE}{input}");
        }
        /// <summary>
        /// Checking the coming input for parsing from string to DateTime and returning the result if its parsed
        /// </summary>
        private static DateTime DateTimeGuard(string input)
        {
            DateTime datetimeOutput;
            var result = DateTime.TryParseExact(input, DATETIMEFORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetimeOutput);
            if (result)
                return datetimeOutput;
            throw new InvalidDataException($"{INVALID_DATETIME_MESSAGE}{input}");
        }
        /// <summary>
        /// Checking the coming input for parsing from string to Enum and returning the result if its parsed
        /// </summary>
        private static Gender EnumGuard(string input)
        {
            Gender genderOutput;
            var result = Enum.TryParse<Gender>(input, out genderOutput);
            if (result)
                return genderOutput;
            throw new InvalidDataException($"{INVALID_ENUM_MESSAGE}{input}");
        }
        /// <summary>
        /// CSV mappers converting the csv items to business model
        /// </summary>
        public static IGrocery CsvMapper(string[] mappingItems) 
        {
            var salary = DoubleGuard(mappingItems[8]);
            var dateOfBirth = DateTimeGuard(mappingItems[5]);
            var gender = EnumGuard(mappingItems[4]);
            
            return new BusinessModels.Grocery
            {
                Id = Guid.Parse(mappingItems[0]),
                FirstName = mappingItems[1].ToString(),
                LastName = mappingItems[2].ToString(),
                Birthday = dateOfBirth,
                Gender = gender,
                Email = mappingItems[3].ToString(),
                JobTitle = mappingItems[6].ToString(),
                DepartmentRetail = mappingItems[7].ToString(),
                Salary = salary,
            };
       }
        /// <summary>
        /// Xlsx mappers converting the Xlsx items to business model
        /// </summary>
        public static IGrocery XlsxMapper(ExcelWorksheet sheet, int index)
        {
            var salary = DoubleGuard(sheet.Cells[index, 0].Value?.ToString());
            var dateOfBirth = DateTimeGuard(sheet.Cells[index, 5].Value?.ToString());
            var gender = EnumGuard(sheet.Cells[index, 5].Value?.ToString());

            return new BusinessModels.Grocery
            {
                Id = Guid.Parse(sheet.Cells[index, 0].Value?.ToString()),
                FirstName = sheet.Cells[index, 1].Value?.ToString(),
                LastName = sheet.Cells[index, 2].Value?.ToString(),
                Birthday = dateOfBirth,
                Gender = gender,
                Email = sheet.Cells[index, 6].Value?.ToString(),
                JobTitle = sheet.Cells[index, 7].Value?.ToString(),
                DepartmentRetail = sheet.Cells[index, 8].Value?.ToString(),
                Salary = salary,
            };      
        }

        public static void MapBusinessModelToDbModel()
        {
           
        }
    }
}
