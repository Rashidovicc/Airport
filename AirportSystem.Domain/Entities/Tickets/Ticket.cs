using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Tickets
{
    public class Ticket : Auditable
    {
        public decimal Price { get; set; }
        public string Seat { get; set; }
        public Status Status { get; set; }
        public DateTime DayOfFlight { get; set; }

        public long PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        public long AeroportId { get; set; }

        [ForeignKey("AeroportId")]
        public Airport Aeroport { get; set; }

        public long AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        public Airplane Airplane { get; set; }


        public long OrderId { get; set; }

        [ForeignKey("AirplaneId")]
        public Order Order { get; set; }

    }
}
