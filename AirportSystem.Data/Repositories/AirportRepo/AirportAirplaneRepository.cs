using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IAirportRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Airports;

namespace AirportSystem.Data.Repositories.AirportRepo
{
    public class AirportAirplaneRepository : GenericRepository<AirportAirplane>, IAirportAirplaneRepository
    {
        public AirportAirplaneRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
