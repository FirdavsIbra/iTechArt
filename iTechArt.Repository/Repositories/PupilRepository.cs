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
            return await _dbContext.Pupils.Select(p => _mapper.Map<Pupil>(p))
                                          .ToArrayAsync();
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public async Task<IPupil> GetByIdAsync(long id)
        {
            return await _dbContext.Pupils.Select(p => _mapper.Map<Pupil>(p))
                                          .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Update pupil
        /// </summary>
        public async Task UpdateAsync(IPupil pupil)
        {
            _dbContext.Pupils.Update(_mapper.Map<PupilDb>(pupil));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete pupil from database
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var pupil = _dbContext.Pupils.FirstOrDefaultAsync(p => p.Id == id);

            if (pupil is not null)
            {
                _dbContext.Pupils.Remove(_mapper.Map<PupilDb>(pupil));
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of pupils
        /// </summary>
        public async Task<int> GetCountOfPupilsAsync()
        {
            return await _dbContext.Pupils.CountAsync();
        }

        /// <summary>
        /// Add pupil array
        /// </summary>
        public async Task AddRangeAsync(IPupil[] pupils)
        {
            PupilDb[] result = new PupilDb[pupils.Length];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = _mapper.Map<PupilDb>(pupils[i]);
            }

            await _dbContext.Pupils.AddRangeAsync(result);

            await _dbContext.SaveChangesAsync();
        }
    }
}
