using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IPassengerRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Passengers;

namespace AirportSystem.Data.Repositories.PassengerRepo
{
    public class PassengerRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
