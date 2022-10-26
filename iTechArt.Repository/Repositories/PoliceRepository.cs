using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Database.Entities.Police;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.EntityFrameworkCore;

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
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IPolice entity)
        {
            var entry = await _dbContext.Set<Police>().AddAsync(_mapper.Map<Police>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all entities from database
        /// </summary>
        public IPolice[] GetAll()
        {
            var models = _dbContext.Police;

            List<IPolice> result = new List<IPolice>();

            foreach (var i in models)
                result.Add(_mapper.Map<IPolice>(i));

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IPolice> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<PoliceDb>().FirstOrDefaultAsync(p => p.Id == id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<IPolice>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(IPolice entity)
        {
            var entry = _dbContext.Set<Police>().Update(_mapper.Map<Police>(entity));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(long id)
        {
            var police = await _dbContext.Police.FirstOrDefaultAsync(d => d.Id == id);

            _dbContext.Police.Remove(_mapper.Map<PoliceDb>(police));

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        public int GetCountOfPolice()
        {
            return _dbContext.Set<Police>().Count();
        }
    }
}
