using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Tickets;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Tickets;
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
    public class TicketService : ITicketService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public TicketService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Ticket> CreateAsync(TicketForCreation ticketForCreation)
        {
            var mappedTicket = mapper.Map<Ticket>(ticketForCreation);

            mappedTicket.Created();

            var result = await unitOfWork.Tickets.CreateAsync(mappedTicket);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Ticket, bool>> expression)
        {
            var exist = await unitOfWork.Tickets.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Ticket not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();
            
            return true;
        }

        public Task<IEnumerable<Ticket>> GetAllAsync(Expression<Func<Ticket, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.Tickets.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                .GetWithPagination(pagination);

            return Task.FromResult(result);
        }


        public async Task<Ticket> GetAsync(Expression<Func<Ticket, bool>> expression)
        {
            var exist = await unitOfWork.Tickets.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Ticket not found!");

            return exist;
        }

        public async Task<Ticket> UpdateAsync(long id, TicketForCreation ticketForCreation)
        {
            var exist = await unitOfWork.Tickets.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Ticket not found!");

            exist = mapper.Map(ticketForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Tickets.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}