using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Majority { get; set; }
        
        public Gender Gender { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public long UniversityId { get; set; }


        [ForeignKey(nameof(UniversityId))]
        public University Course { get; set; }
    }
}
