using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.ITicketRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Tickets;

namespace AirportSystem.Data.Repositories.TicketRepo
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
