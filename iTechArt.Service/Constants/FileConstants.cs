using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Constants
{
    public static class FileConstants
    {
        /// <summary>
        /// types of extensions
        /// </summary>
        public static readonly string[] Extensions = { ".xlsx", ".xls", ".csv", ".xml" };

        /// <summary>
        /// excel extensions
        /// </summary>
        public static readonly string[] excelExtensions = { ".xlsx", ".xls", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xlt", ".xlam", ".xla", ".xlw" };
        
        /// <summary>
        /// csv extensions
        /// </summary>
        public static readonly string[] csvExtensions = { ".csv" };


        /// <summary>
        /// xml extensions
        /// </summary>
        public static readonly string[] xmlExtensions = { ".xml" };

        /// <summary>
        /// Content types of CSV files
        /// </summary>
        public static readonly string[] CSV =
        {
            "text/csv"
        };

        /// <summary>
        /// Content types of XML files
        /// </summary>
        public static readonly string[] XML =
        {
            "text/xml",
            "application/xml",
            "application/xaml+xml",
            "application/xhtml+xml"
        };

        /// <summary>
        /// Content types of EXCEL files
        /// </summary>
        public static readonly string[] EXCEL =
        {
            "application/vnd.ms-excel",
            "application/vnd.ms-excel.sheet.macroEnabled.12",
            "application/vnd.ms-excel.addin.macroEnabled.12",
            "application/vnd.ms-excel.template.macroEnabled.12",
            "application/vnd.ms-excel.sheet.binary.macroEnabled.12",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.template"
        };
    }
}
