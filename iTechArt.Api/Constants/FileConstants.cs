namespace iTechArt.Api.Constants
{
    public static class FileConstants
    {
        /// <summary>
        /// Types of extensions.
        /// </summary>
        public static readonly string[] Extensions = { ".csv", ".xml",".xlsx", ".xls", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xlt", ".xlam", ".xla", ".xlw" };

        /// <summary>
        /// Constant file extension strings.
        /// </summary>
        public static readonly string csv = ".csv";
        public static readonly string xml = ".xml";
        public static readonly string xlsx = ".xlsx";
        public static readonly string xls = ".xls";

        /// <summary>
        /// Content types of CSV files.
        /// </summary>
        public static readonly string[] CSV =
        {
            "text/csv"
        };

        /// <summary>
        /// Content types of XML files.
        /// </summary>
        public static readonly string[] XML =
        {
            "text/xml",
            "application/xml",
            "application/xaml+xml",
            "application/xhtml+xml"
        };

        /// <summary>
        /// Content types of EXCEL files.
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
