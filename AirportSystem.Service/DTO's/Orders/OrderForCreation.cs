using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Service.DTO_s.Orders
{
    public class OrderForCreation
    {
        public bool IsPaid { get; set; } = false;

        [Required(AllowEmptyStrings = false)]
        public long PassengerId { get; set; }


        [Required(AllowEmptyStrings = false)]
        public long TicketId { get; set; }

    }
}