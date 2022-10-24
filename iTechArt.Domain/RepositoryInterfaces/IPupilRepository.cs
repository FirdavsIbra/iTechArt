using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository : IRepository<IPupil, Pupil>
    {
        /// </summary>
        /// Get count of pupils
        /// </summary>
        public int GetCountOfPupils();
    }
}
