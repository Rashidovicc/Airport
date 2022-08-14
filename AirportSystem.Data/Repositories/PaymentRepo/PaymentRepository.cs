using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IPaymentRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Payments;

namespace AirportSystem.Data.Repositories.PaymentRepo
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
