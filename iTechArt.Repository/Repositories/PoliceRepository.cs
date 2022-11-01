using AutoMapper;
using CsvHelper;
using iTechArt.Database.DbContexts;
using iTechArt.Database.Entities.Police;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.BusinessModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace iTechArt.Repository.Repositories
{
    public sealed class PoliceRepository : IPoliceRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PoliceRepository(AppDbContext dbContext,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Add or Update Police entity to/from database
        /// </summary>
        /// <param name="entity"></param>   
        public async Task AddAsync(IPolice entity)
        {
            PoliceDb police = _mapper.Map<PoliceDb>(entity);
            if (entity != null)
            {
                _dbContext.Police.Add(police);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all Police data from database
        /// </summary>
        public async Task<IPolice[]> GetAllAsync()
        {
            IPolice[] policeArray = _dbContext.Police.Select(police => _mapper.Map<Police>(police)).ToArray();
            return policeArray;
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
        public async Task UpdateAsync(IPolice entity)
        {
            var policeFromDb = await _dbContext.Police.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (policeFromDb != null)
            {
                _dbContext.Police.Update(_mapper.Map<PoliceDb>(entity));
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds collection of entities to the database
        /// </summary>
        /// <param name="police"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(List<IPolice> polices)
        {
            PoliceDb[] policesArray = polices.Select(c => _mapper.Map<PoliceDb>(c)).ToArray();
            await _dbContext.Police.AddRangeAsync(policesArray);
        }
    }
}