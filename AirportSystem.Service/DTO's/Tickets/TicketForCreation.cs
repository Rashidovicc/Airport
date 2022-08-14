using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Enums;

namespace AirportSystem.Service.DTO_s.Tickets
{
    public class TicketForCreation
    {
        [Required(AllowEmptyStrings = false)]
        public decimal Price { get; set; }

        
        [Required(AllowEmptyStrings = false),MaxLength(10)]
        public string Seat { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public Status Status { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public DateTime DayOfFlight { get; set; }


        [Required(AllowEmptyStrings = false)]
        public long PassengerId { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public long AeroportId { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public long AirplaneId { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public long OrderId { get; set; }
    }
}