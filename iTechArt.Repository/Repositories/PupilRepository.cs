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
        public IPupil[] GetAllAsync()
        {
            var pupils = _dbContext.Pupils;

            List<IPupil> result = new List<IPupil>();

            foreach (var pupil in pupils)
            {
                result.Add(_mapper.Map<Pupil>(pupil));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get pupil by id
        /// </summary>
        public async Task<IPupil> GetByIdAsync(long id)
        {
            var pupils = _dbContext.Pupils;

            var pupilDb = await pupils.FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<Pupil>(pupilDb);
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
            var pupils = _dbContext.Pupils;

            var pupil = await pupils.FirstOrDefaultAsync(p => p.Id == id);

            _dbContext.Pupils.Remove(_mapper.Map<PupilDb>(pupil));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of pupils
        /// </summary>
        public int GetCountOfPupils()
        {
            return _dbContext.Pupils.Count();
        }
    }
}
