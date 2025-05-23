﻿using NZtut.API.Models.Domain;

namespace NZtut.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int PageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteByIdAsync(Guid id);
    }
}
