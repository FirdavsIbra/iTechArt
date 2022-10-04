using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.Airports
{
    public class Flight : Auditable
    {
        public long AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public long FromAirportId { get; set; }
        [ForeignKey(nameof(FromAirportId))]
        public Airport Airport { get; set; }

        public long ToAirportId { get; set; }
        [ForeignKey(nameof(ToAirportId))]
        public Airport ToAirport { get; set; }
    }
}
