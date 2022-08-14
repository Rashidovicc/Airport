using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Orders;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Service.Services
{
#pragma warning disable
    public class OrderService : IOrderService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Order> CreateAsync(OrderForCreation orderForCreation)
        {
            var exist = await unitOfWork.Orders.GetAsync(prop => prop.PassengerId == orderForCreation.PassengerId);

            if (exist is not null)
                throw new Exception("This Order already exists!");

            var mappedOrder = mapper.Map<Order>(orderForCreation);

            mappedOrder.Created();

            var result = await unitOfWork.Orders.CreateAsync(mappedOrder);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var exist = await unitOfWork.Orders.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Order not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();

            return true;
        }


        public  Task<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
        {
            var exist = unitOfWork.Orders.GetAll(expression)
                .Where(expressio => expressio.ItemState == ItemState.Deleted)
                .Include(o => o.Passenger)
                .Include(o => o.IsPaid == true)
                .Include(o => o.Ticket);
            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Orders not found");

            return Task.FromResult<IEnumerable<Order>>(exist);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var exist = await unitOfWork.Orders.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Order not found!");

            return exist;
        }

        public async Task<Order> UpdateAsync(long id, OrderForCreation orderForCreation)
        {
            var exist = await unitOfWork.Orders.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Order not found!");

            exist = mapper.Map(orderForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Orders.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}