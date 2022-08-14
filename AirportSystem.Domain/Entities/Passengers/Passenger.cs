using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Domain.Entities.Passengers
{
    public class Passenger : Auditable
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(16)]
        public string Phone { get; set; }
        
        [MaxLength(64)]
        public string UserName { get; set; }
        
        [MaxLength(64)]
        public string Email { get; set; }
        [MaxLength(16)]
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string CountryCode { get; set; }
        public string Address { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public bool IsBlackList { get; set; } = false;

    }
}
