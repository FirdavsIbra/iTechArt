﻿using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IAirportRepository
    {
        /// <summary>
        /// Get all airports from database
        /// </summary>
        Task<IAirport[]> GetAllAsync();

        /// <summary>
        /// Add array of airport
        /// </summary>
        Task AddRangeAsync(IEnumerable<IAirport> airports);

        /// <summary>
        /// Add airport to database
        /// </summary>
        Task AddAsync(IAirport airport);

        /// <summary>
        /// Get airport by id
        /// </summary>
        Task<IAirport> GetByIdAsync(long id);

        /// <summary>
        /// Update airport
        /// </summary>
        Task UpdateAsync(IAirport airport);

        /// <summary>
        /// Delete airport from database
        /// </summary>
        Task DeleteAsync(long id);

        /// </summary>
        /// Get count of airports
        /// </summary>
        public Task<int> GetCountOfAirportAsync();
    }
}
