using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task AddAsync(IPupil pupil)
        {
            await _dbContext.Pupils.AddAsync(_mapper.Map<PupilDb>(pupil));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all pupils
        /// </summary>
        public async Task<IPupil[]> GetAllAsync()
        {
            var pupils = await _dbContext.Pupils.ToArrayAsync();

            IPupil[] result = new IPupil[_dbContext.Pupils.Count()];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = _mapper.Map<IPupil>(pupils[i]);
            }

            return result;
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public async Task<IPupil> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<PupilDb>().FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<Pupil>(databaseModel);
        }

        /// <summary>
        /// Update pupil
        /// </summary>
        public async Task UpdateAsync(IPupil pupil)
        {
            _dbContext.Set<PupilDb>().Update(_mapper.Map<PupilDb>(pupil));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var pupil = await _dbContext.Set<PupilDb>().FirstOrDefaultAsync(p => p.Id == id);

            _dbContext.Set<PupilDb>().Remove(_mapper.Map<PupilDb>(pupil));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of pupils
        /// </summary>
        public int GetCountOfPupils()
        {
            return _dbContext.Set<PupilDb>().Count();
        }
    }
}
