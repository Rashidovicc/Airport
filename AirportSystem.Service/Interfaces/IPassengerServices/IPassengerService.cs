using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Service.DTO_s.Passengers;

namespace AirportSystem.Service.Interfaces.IPassengerServices
{
    public interface IPassengerService
    {
        Task<Passenger> CreateAsync(PassengerForCreation passengerForCreation);
        Task<Passenger> UpdateAsync(long id, PassengerForCreation passengerForCreation);
        Task<bool> DeleteAsync(Expression<Func<Passenger, bool>> expression);
        Task<IEnumerable<Passenger>> GetAllAsync(Expression<Func<Passenger, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<Passenger> GetAsync(Expression<Func<Passenger, bool>> expression);
        Task<bool> CheckingBlacklist(Expression<Func<Passenger, bool>> expression);
       
    }
}