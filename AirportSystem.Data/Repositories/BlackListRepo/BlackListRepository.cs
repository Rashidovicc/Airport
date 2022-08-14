using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IBlackListRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.BlackLists;

namespace AirportSystem.Data.Repositories.BlackListRepo
{
    public class BlackListRepository : GenericRepository<BlackList>, IBlackListRepository
    {
        public BlackListRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
