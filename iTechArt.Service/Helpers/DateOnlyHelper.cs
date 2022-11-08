using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace iTechArt.Service.Helpers
{
    public class DateOnlyHelper : StringTypeConverterBase<DateOnly>
    {
        protected override DateOnly Parse(string s) => DateOnly.Parse(s);

        protected override string ToIsoString(DateOnly source) => source.ToString();
    }
}
