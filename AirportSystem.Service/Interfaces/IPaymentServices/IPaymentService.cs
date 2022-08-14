using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Service.DTO_s.Payments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreateAsync(PaymentForCreation paymentForCreation);
        Task<Payment> UpdateAsync(long id, PaymentForCreation paymentForCreation);
        Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression);
        Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
    }
}