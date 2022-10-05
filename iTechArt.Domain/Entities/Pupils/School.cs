using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;

namespace iTechArt.Domain.Entities.Pupils
{
    public class School : Auditable
    {
        public int SchoolNumber { get; set; }
        public string Address { get; set; }
        public SchoolType SchoolType { get; set; }

    }
}