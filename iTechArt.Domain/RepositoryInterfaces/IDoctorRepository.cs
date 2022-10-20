using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IDoctorRepository : IRepository<IDoctor>
    {
        public int GetCountOfDoctors();
    }
}
