using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IOrderRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Orders;

namespace AirportSystem.Data.Repositories.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
