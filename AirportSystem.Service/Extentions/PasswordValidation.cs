using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AirportSystem.Service.Extentions
{
    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value.ToString();

            if (password!.Length < 6)
                return new ValidationResult("Password must be at least 6 characters long");
            if (password!.Length > 20)
                return new ValidationResult("Password must be less than 20 characters long");
            if (!password.Any(char.IsUpper))
                return new ValidationResult("Password must contain at least one uppercase letter");
            if(!password.Any(char.IsLower))
                return new ValidationResult("Password must contain at least one lowercase letter");
            if(!password.Any(char.IsDigit))
                return new ValidationResult("Password must contain at least one digit");
            else
                return ValidationResult.Success;
           
        }
    }
}