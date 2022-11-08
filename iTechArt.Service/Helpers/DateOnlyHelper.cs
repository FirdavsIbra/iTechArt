using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace iTechArt.Service.Helpers
{
    internal class DateOnlyHelper : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return new DateOnly(2000, 12, 12);
        }
    }
}
