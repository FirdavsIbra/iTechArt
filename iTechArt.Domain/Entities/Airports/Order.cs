using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.Airports
{
    public class Order : Auditable
    {
        public long TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }

        public long PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public User User { get; set; }
    }
}
