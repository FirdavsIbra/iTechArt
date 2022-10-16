using System.ComponentModel.DataAnnotations;

namespace iTechArt.Domain.Entities.Police
{
    public sealed class Police
    {
        [Key]
        [Required]
        public int OfficerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string JobTitle { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
