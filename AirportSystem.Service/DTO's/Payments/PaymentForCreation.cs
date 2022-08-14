using System.ComponentModel.DataAnnotations;
using AirportSystem.Domain.Enums;

namespace AirportSystem.Service.DTO_s.Payments
{
    public class PaymentForCreation
    {
        [Required(AllowEmptyStrings = false)]
        public PaymentType PaymentType { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public long OrderId { get; set; }
        
    }
}