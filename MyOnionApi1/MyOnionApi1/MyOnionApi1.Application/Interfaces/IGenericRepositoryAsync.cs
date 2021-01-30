﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnionApi1.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
