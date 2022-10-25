using iTechArt.Database.DbContexts;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Database.Entities.Police;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using iTechArt.Repository.BusinessModels;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : IPoliceRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public PoliceRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add police to database
        /// </summary>
        /// <param name="police"></param>   
        public async Task AddAsync(IPolice police)
        {
            await _dbContext.Set<PoliceDb>().AddAsync(_mapper.Map<PoliceDb>(police));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all polices from database
        /// </summary>
        public IPolice[] GetAll()
        {
            var polices = _dbContext.Set<PoliceDb>();

            List<IPolice> result = new List<IPolice>();

            foreach (var police in polices)
            {
                result.Add(_mapper.Map<Police>(police));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get police by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IPolice> GetByIdAsync(long id)
        {
            var policeDb = await _dbContext.Set<PoliceDb>().FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<Police>(policeDb);
        }

        /// <summary>
        /// Update police
        /// </summary>
        /// <param name="police"></param>
        public async Task UpdateAsync(IPolice police)
        {
            _dbContext.Set<PoliceDb>().Update(_mapper.Map<PoliceDb>(police));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete police from database
        /// </summary>
        /// <param name="police"></param>
        public async Task DeleteAsync(long id)
        {
            var police = await _dbContext.Set<PoliceDb>().FirstOrDefaultAsync(p => p.Id == id);

            _dbContext.Set<PoliceDb>().Remove(_mapper.Map<PoliceDb>(police));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        public int GetCountOfPolice()
        {
            return _dbContext.Set<PoliceDb>().Count();
        }
    }
}
