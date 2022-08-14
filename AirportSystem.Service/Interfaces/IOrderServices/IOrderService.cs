using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Service.DTO_s.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(OrderForCreation orderForCreation);
        Task<Order> UpdateAsync(long id, OrderForCreation orderForCreation);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
    }
}