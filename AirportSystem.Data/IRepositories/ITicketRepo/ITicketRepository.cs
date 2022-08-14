using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Entities.Tickets;

namespace AirportSystem.Data.IRepositories.ITicketRepo
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
    }
}
