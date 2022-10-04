using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public class Company: Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual IEnumerable<Airplane> Airplanes { get; set; }
    }
}