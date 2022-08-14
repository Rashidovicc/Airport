using AirportSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.Employees
{
    public class EmployeeForCreation
    {
        [Required(AllowEmptyStrings = false),MaxLength(64)]
        public string FirstName { get; set; }

        
        [Required(AllowEmptyStrings = false), MaxLength(64)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(64)]
        public string UserName { get; set; }
        
        [Required(AllowEmptyStrings = false), EmailAddress]
        public string Email { get; set; }
        

        [Required(AllowEmptyStrings = false)]
        public DateTime DateOfBirth { get; set; }
        

        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        

        [Required, MaxLength(32)]
        public string PassportNumber { get; set; }

        
        [Required, MaxLength(16),Phone]
        public string Phone { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public Gender Gender { get; set; }


        [Required(AllowEmptyStrings = false)]
        public Department Department { get; set; }

        
        [Required, DataType(DataType.Password),JsonIgnore]
        public string Password { get; set; }
        

        [Required(AllowEmptyStrings = false)]
        public decimal Salary { get; set; }
    }
}
