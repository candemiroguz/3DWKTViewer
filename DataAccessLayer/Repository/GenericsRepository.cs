using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericsRepository<T> : IGenericsRepository<T> where T : class
    {

        private readonly DbContextConnection _context;

        public GenericsRepository(DbContextConnection context)
        {
            _context = context;
        }

        public async Task AddAsync(T e)
        {
            await _context.Set<T>().AddAsync(e);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T e)
        {
            _context.Set<T>().Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T e)
        {
            _context.Set<T>().Update(e);
            await _context.SaveChangesAsync();
        }
        public async Task<List<String>> GetGeoJsonDataAsync()
        {
            var asd = await _context.Geometries
                .OrderByDescending(x =>x.Id)
                .Select(x=>x.GeoJsonGeom)
                .ToListAsync();
            return asd;
            
        }

    }
}
