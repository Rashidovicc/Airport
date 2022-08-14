using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Entities.Orders;

namespace AirportSystem.Data.IRepositories.IOrderRepo
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
