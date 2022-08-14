using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.RouleTables
{
    public class RouleTable : Auditable
    {
        public long AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        public Airplane Airplane { get; set; }

        public FlightStatus FligthStatus { get; set; }

    }
}
