using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Service.DTO_s.Employees
{
    public class EmployeeForChangePassword
    {
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string OldPassword { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string NewPassword { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ConfirmPassword { get; set; }
    }
}