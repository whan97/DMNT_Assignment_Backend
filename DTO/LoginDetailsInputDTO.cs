using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demant_Assignment.Application.DTO
{
    public class LoginDetailsInputDTO : IValidatableObject
    {
        [Required(ErrorMessage = "UserName should not be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password should not be empty")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Maximum 30 characters and minimum 8 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password should contain one Special Type character, one Upper Case and one Lower Case letter.")]
        public string Password { get; set; }
   

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}