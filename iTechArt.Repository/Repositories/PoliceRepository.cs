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
        /// Add or Update Police entity to/from database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddUpdateAsync(IPolice entity)
        {
            PoliceDb police = _mapper.Map<PoliceDb>(entity);
            if (entity != null)
            {
                if (entity.Id > 0)
                {
                    _dbContext.Police.Update(police);
                }
                else
                {
                    _dbContext.Police.Add(police);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all Police data from database
        /// </summary>
        public async Task<IPolice[]> GetAllAsync()
        {
            IEnumerable<IPolice> polices = _dbContext.Police.Select(c => _mapper.Map<IPolice>(c));
            return polices.ToArray();
        }

        /// <summary>
        /// Get Police by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IPolice> GetByIdAsync(long id)
        {
            var entityFromDb = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == id);

            if (entityFromDb != null)
            {
                var ipolice = _mapper.Map<IPolice>(entityFromDb);
                return ipolice;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Police from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(long id)
        {
            var police = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == id);
            if (police != null)
            {
                _dbContext.Police.Remove(police);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get total count of police
        /// </summary>
        public int GetCountOfPolice()
        {
            return _dbContext.Police.Count();
        }

        ///// <summary>
        ///// Update entity
        ///// </summary>
        ///// <param name="entity"></param>
        //public async Task UpdateAsync(IPolice entity)
        //{
        //    var entry = _dbContext.Set<PoliceDb>().Update(_mapper.Map<PoliceDb>(entity));

        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
