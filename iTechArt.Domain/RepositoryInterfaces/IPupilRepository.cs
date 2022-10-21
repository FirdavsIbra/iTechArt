using iTechArt.Database.Entities.Pupils;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository : IRepository<Pupil>
    {
        /// <summary>
        /// Return Number Of Pupils
        /// </summary>
        public int GetCountOfPupils();
    }
}
