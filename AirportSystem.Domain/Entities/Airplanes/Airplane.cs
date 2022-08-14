using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Airports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Airplanes
{
    public class Airplane : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Country { get; set; }
        public string FromToDestination { get; set; }
        public string ToDestination { get; set; }

        public long AeroportId { get; set; }

        [ForeignKey("AeroportId")]
        public Airport Aeroport { get; set; }

    }
}
