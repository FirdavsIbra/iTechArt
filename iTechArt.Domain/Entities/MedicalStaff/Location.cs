using iTechArt.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Location : Auditable
    {
        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public long CityId { get; set; }
    }
}
