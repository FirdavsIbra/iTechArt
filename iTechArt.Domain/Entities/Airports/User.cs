using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public class User : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
