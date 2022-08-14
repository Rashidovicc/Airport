using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IRouleTableRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.RouleTables;

namespace AirportSystem.Data.Repositories.RouleTableRepo
{
    public class RouleTableRepository : GenericRepository<RouleTable>, IRouleTableRepository
    {
        public RouleTableRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
