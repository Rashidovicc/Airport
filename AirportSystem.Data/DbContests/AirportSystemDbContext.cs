using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Domain.Entities.BlackLists;
using AirportSystem.Domain.Entities.Employees;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Data.DbContests
{
    public class AirportSystemDbContext : DbContext
    {
        private readonly string ConnectionString = "Host=localhost;Port=5432;Database=Aeraport;Username=postgres;Password=botir1202;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<RouleTable> RoulTables { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<AirportAirplane> AirportAirplanes { get; set; }
    }
}
