using System.ComponentModel.DataAnnotations;
using AirportSystem.Domain.Enums;

namespace AirportSystem.Service.DTO_s.Passengers
{
    public class PassengerForCreation
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        
        [Required(AllowEmptyStrings = false),Phone]
        public string Phone { get; set; }

        
        [MaxLength(64),Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        
        [MaxLength(16),Required(AllowEmptyStrings = false)]
        public string PassportNumber { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public Gender Gender { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public string CountryCode { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public AgeCategory AgeCategory { get; set; }

        public bool IsBlackList { get; set; } = false;
    }
}