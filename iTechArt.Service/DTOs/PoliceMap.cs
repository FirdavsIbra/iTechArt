using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.DTOs
{
    public class PoliceMap : ClassMap<PoliceDto>
    {
        public PoliceMap()
        {
            Map(c => c.Name).Name("Name");
            Map(c => c.Surname).Name("Surname");
            Map(c => c.Email).Name("Email");
            Map(c => c.Gender).Name("Gender");
            Map(c => c.Address).Name("Address");
            Map(c => c.JobTitle).Name("JobTitle");
            Map(c => c.Salary).Name("Salary");
        }
    }
}
