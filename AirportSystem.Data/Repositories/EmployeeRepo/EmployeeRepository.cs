using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.IEmployeeRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.EmployeeRepo
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
