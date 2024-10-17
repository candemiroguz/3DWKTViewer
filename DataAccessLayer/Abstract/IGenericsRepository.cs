using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericsRepository<T> where T : class
    {
        Task AddAsync(T e);
        Task UpdateAsync(T e);
        Task DeleteAsync(T e);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetListAsync();
        Task<List<String>> GetGeoJsonDataAsync();
    }
}
