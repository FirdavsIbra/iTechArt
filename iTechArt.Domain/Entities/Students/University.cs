using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Students
{
    public class University : Auditable
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}