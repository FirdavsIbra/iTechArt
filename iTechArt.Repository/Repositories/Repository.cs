using AutoMapper;
using iTechArt.Database.DbContexts;
using iTechArt.Domain.RepositoryInterfaces;

namespace iTechArt.Repository.Repositories
{
    public abstract class Repository<RepoModel, DatabaseModel> : IRepository<RepoModel, DatabaseModel> 
        where RepoModel : class 
        where DatabaseModel : class, IDbModel
    {
        protected readonly AppDbContext _dbContext;
        protected readonly IMapper _mapper;
        public Repository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(DatabaseModel entity)
        {
            var entry = await _dbContext.Set<DatabaseModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        /// <summary>
        /// Get all entities from database
        /// </summary>
        public RepoModel[] GetAll()
        {
            var models = _dbContext.Set<DatabaseModel>();

            List<RepoModel> result = new List<RepoModel>();

            foreach(var i in models)
                result.Add(_mapper.Map<RepoModel>(i));

            return result.ToArray();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        public async Task<RepoModel> GetByIdAsync(long id)
        {
            var databaseModel = await _dbContext.Set<DatabaseModel>().FindAsync(id);

            if (databaseModel is null)
                return null;

            return _mapper.Map<RepoModel>(databaseModel);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task UpdateAsync(DatabaseModel entity)
        {
            var entry = _dbContext.Set<DatabaseModel>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(DatabaseModel entity)
        {
            _dbContext.Set<DatabaseModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}