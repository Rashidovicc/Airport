using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Service.DTO_s.Employees
{
    public class EmployeeForLogin
    {
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}