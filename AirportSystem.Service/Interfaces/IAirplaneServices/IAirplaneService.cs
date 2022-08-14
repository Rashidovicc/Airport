using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Service.DTO_s.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IAirplaneService
    {
        Task<Airplane> CreateAsync(AirplaneForCreation airplaneForCreation);
        Task<Airplane> UpdateAsync(long id, AirplaneForCreation airplaneForCreation);
        Task<bool> DeleteAsync(Expression<Func<Airplane, bool>> expression);
        Task<IEnumerable<Airplane>> GetAllAsync(Expression<Func<Airplane, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<Airplane> GetAsync(Expression<Func<Airplane, bool>> expression);
    }
}
