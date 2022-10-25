using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public sealed class PupilRepository : IPupilRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public PupilRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add pupil to database
        /// </summary>
        /// <param name="pupil"></param>
        public async Task AddAsync(IPupil pupil)
        {
            var pupilDb = _mapper.Map<Pupil>(pupil);

            await _dbContext.Set<Pupil>().AddAsync(pupilDb);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        public IPupil[] GetAll()
        {
            var pupils = _dbContext.Set<Pupil>();

            List<IPupil> result = new List<IPupil>();

            foreach (var pupil in pupils)
                result.Add(_mapper.Map<IPupil>(pupil));

            return result.ToArray();
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IPupil> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<Pupil>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IPupil>(databaseModel);
        }

        /// <summary>
        /// Update pupil
        /// </summary>
        /// <param name="pupil"></param>
        public async Task UpdateAsync(IPupil pupil)
        {
            _dbContext.Set<Pupil>().Update(_mapper.Map<Pupil>(pupil));
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        /// <param name="pupil"></param>
        public async Task DeleteAsync(IPupil pupil)
        {
            _dbContext.Set<Pupil>().Remove(_mapper.Map<Pupil>(pupil));
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of pupils
        /// </summary>
        public int GetCountOfPupils()
        {
            return _dbContext.Set<Pupil>().Count();
        }
    }
}
