using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.RouleTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.Airports
{
    public class Airport : Auditable
    {
        [MaxLength(60)]
        public string Name { get; set; }
        public string Address { get; set; }

        public long RouleTableId { get; set; }

        [ForeignKey("RoleTableId")]
        public RouleTable RouleTable { get; set; }

        public long AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        public Airplane Airplane { get; set; }
    }
}
