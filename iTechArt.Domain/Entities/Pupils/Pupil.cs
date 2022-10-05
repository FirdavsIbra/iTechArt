using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;

namespace iTechArt.Domain.Entities.Pupils
{
    public class Pupil : Auditable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public School School { get; set; }
        public int Grade { get; set; }
        public string CourseLanguage { get; set; }
        public Shift Shift { get; set; }
    }
}
