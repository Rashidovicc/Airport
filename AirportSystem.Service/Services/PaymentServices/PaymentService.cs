using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Payments;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Payment> CreateAsync(PaymentForCreation paymentForCreation)
        {
            var exist = await unitOfWork.Payments.GetAsync(a => a.OrderId == paymentForCreation.OrderId);

            var order = await unitOfWork.Orders.GetAsync(o => o.Id == paymentForCreation.OrderId);

            if (order is null || order.IsPaid)
                throw new Exception("Order not found");

            var passenger = await unitOfWork.Passengers.GetAsync(p => p.Id == order.PassengerId);

            if (passenger is null)
                throw new Exception("This passenger not found");

            order.IsPaid = true;
            order.Updated();
            
            var mappedPayment = mapper.Map<Payment>(paymentForCreation);

            mappedPayment.Created();

            var result = await unitOfWork.Payments.CreateAsync(mappedPayment);

            unitOfWork.Orders.UpdateAsync(order);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
        {
            var exist = await unitOfWork.Payments.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Payment not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.Payments.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                .GetWithPagination(pagination);

            return Task.FromResult(result);
        }


        public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            var exist = await unitOfWork.Payments.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Payment not found!");

            return exist;
        }

        public async Task<Payment> UpdateAsync(long id, PaymentForCreation paymentForCreation)
        {
            var exist = await unitOfWork.Payments.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Payment not found!");

            exist = mapper.Map(paymentForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Payments.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}