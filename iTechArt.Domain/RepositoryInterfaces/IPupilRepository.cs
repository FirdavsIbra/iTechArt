using iTechArt.Database.Entities.Pupils;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IPupilRepository : IRepository<Pupil>
    {
        /// </summary>
        /// Get count of pupils
        /// </summary>
        /// <returns></returns>
        public int GetCountOfPupils();
    }
}
