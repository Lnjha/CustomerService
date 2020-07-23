using CustomerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
    }
}