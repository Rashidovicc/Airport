using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.CommonRepo
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly AirportSystemDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AirportSystemDbContext airportSystemContext)
        {
            _context = airportSystemContext;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);

            if (entity is  null)
            {
                return false;
            }
            _dbSet.Remove(entity);

            return true;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => _dbSet.FirstOrDefaultAsync(expression);

        public T UpdateAsync(T entity)
            => _dbSet.Update(entity).Entity;

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
            => expression is null ? _dbSet : _dbSet.Where(expression);

    }
}
