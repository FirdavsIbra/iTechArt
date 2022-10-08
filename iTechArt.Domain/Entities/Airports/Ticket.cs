using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.Airports
{
    public class Ticket : Auditable
    {
        public decimal Price { get; set; }
        public string Seat { get; set; }

        public long FlightId { get; set; }
        [ForeignKey(nameof(FlightId))]
        public Flight Flight { get; set; }
    }
}
