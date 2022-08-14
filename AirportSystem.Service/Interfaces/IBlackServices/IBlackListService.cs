using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.BlackLists;
using AirportSystem.Service.DTO_s.BlackLists;

namespace AirportSystem.Service.Interfaces
{
    public interface IBlackListService
    {
        Task<BlackList> CreateAsync(BlackListForCreation blackListForCreation);
        Task<BlackList> UpdateAsync(long id, BlackListForCreation blackListForCreation);
        Task<bool> DeleteAsync(Expression<Func<BlackList, bool>> expression);
        Task<IEnumerable<BlackList>> GetAllAsync( Expression<Func<BlackList, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<BlackList> GetAsync(Expression<Func<BlackList, bool>> expression);
    }
}