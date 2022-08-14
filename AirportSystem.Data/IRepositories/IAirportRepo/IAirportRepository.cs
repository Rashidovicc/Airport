using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Entities.Airports;

namespace AirportSystem.Data.IRepositories.IAirportRepo
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
    }
}
