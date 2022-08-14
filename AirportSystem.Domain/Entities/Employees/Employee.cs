using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;


namespace AirportSystem.Domain.Entities.Employees
{
    public class Employee : Auditable
    {
        
        [MaxLength(64)]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        public string LastName { get; set; }
        
        [MaxLength(64)]
        public string UserName { get; set; }
        
        [MaxLength(16)]
        public string Phone { get; set; }
        
        [MaxLength(64)]
        public string Email { get; set; }
        [MaxLength(16)]
        public string PassportNumber { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        
        
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department Department { get; set; }
    }
}
