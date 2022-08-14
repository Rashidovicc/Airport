using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Entities.Employees;
using AirportSystem.Domain.Entities.Passengers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Domain.Entities.BlackLists
{
    public class BlackList : Auditable
    {
        public DateTime Duration { get; set; }

        public long PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }
    }
}
