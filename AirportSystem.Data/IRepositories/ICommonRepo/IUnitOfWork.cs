using AirportSystem.Data.IRepositories.IAirplaneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories.IAirportRepo;
using AirportSystem.Data.IRepositories.IBlackListRepo;
using AirportSystem.Data.IRepositories.IEmployeeRepo;
using AirportSystem.Data.IRepositories.IOrderRepo;
using AirportSystem.Data.IRepositories.IPassengerRepo;
using AirportSystem.Data.IRepositories.IPaymentRepo;
using AirportSystem.Data.IRepositories.IRouleTableRepo;
using AirportSystem.Data.IRepositories.ITicketRepo;

namespace AirportSystem.Data.IRepositories.ICommonRepo
{
    public interface IUnitOfWork : IDisposable
    {
        IAirplaneRepository Airplanes { get; }
        IAirportAirplaneRepository AirportAirplanes { get; }
        IAirportRepository Airports { get; }
        IBlackListRepository BlackLists { get; }
        ITicketRepository Tickets { get; }
        IRouleTableRepository RouleTables { get; }
        IEmployeeRepository Employees { get; }
        IOrderRepository Orders { get; }
        IPassengerRepository Passengers { get; }
        IPaymentRepository Payments { get; }

        Task SaveChangesAsync();

    }
}
