using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Service.DTO_s.RoulTable;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IRoulTableService
    {
        Task<RouleTable> CreateAsync(RoulTableForCreation rouleTableForCreation);
        Task<RouleTable> UpdateAsync(long id, RoulTableForCreation rouleTableForCreation);
        Task<bool> DeleteAsync(Expression<Func<RouleTable, bool>> expression);
        Task<IEnumerable<RouleTable>> GetAllAsync( Expression<Func<RouleTable, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<RouleTable> GetAsync(Expression<Func<RouleTable, bool>> expression);
    }
}