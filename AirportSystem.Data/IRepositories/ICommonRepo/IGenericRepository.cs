using AirportSystem.Domain.Commons;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Data.IRepositories.ICommonRepo
{
    public interface IGenericRepository<T> where T : Auditable
    {
        Task<T> CreateAsync(T entity);
        T UpdateAsync(T entity);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
    }
}
