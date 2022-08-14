using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Airplanes;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Airports
{
    public class AirportAirplane : Auditable
    {
        public long AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        public Airplane Airplane { get; set; }

        public long AeroportId { get; set; }

        [ForeignKey("AeroportId")]
        public Airport Aeroport { get; set; }
    }
}
