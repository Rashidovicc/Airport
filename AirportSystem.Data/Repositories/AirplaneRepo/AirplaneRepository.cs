using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IAirplaneRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Airplanes;

namespace AirportSystem.Data.Repositories.AirplaneRepo
{
    public class AirplaneRepository : GenericRepository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
