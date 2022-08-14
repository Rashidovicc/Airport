using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Tickets;
using AirportSystem.Service.DTO_s.Tickets;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> CreateAsync(TicketForCreation ticketForCreation);
        Task<Ticket> UpdateAsync(long id, TicketForCreation ticketForCreation);
        Task<bool> DeleteAsync(Expression<Func<Ticket, bool>> expression);
        Task<IEnumerable<Ticket>> GetAllAsync(Expression<Func<Ticket, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<Ticket> GetAsync(Expression<Func<Ticket, bool>> expression);
    }
}