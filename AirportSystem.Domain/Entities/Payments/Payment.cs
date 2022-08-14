using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Payments
{
    public class Payment : Auditable
    {
        public PaymentType PaymentType { get; set; }
        public long OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
