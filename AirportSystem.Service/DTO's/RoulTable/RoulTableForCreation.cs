using System.ComponentModel.DataAnnotations;
using AirportSystem.Domain.Enums;

namespace AirportSystem.Service.DTO_s.RoulTable
{
    public class RoulTableForCreation
    {
        [Required(AllowEmptyStrings = false)]
        public long AirplaneId { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public FlightStatus FligthStatus { get; set; }
    }
}