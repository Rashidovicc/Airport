using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Entities.Tickets;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public bool IsPaid { get; set; }
        public long PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        public long TicketId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
