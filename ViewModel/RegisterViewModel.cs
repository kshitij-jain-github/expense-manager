using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.ViewModel
{
    [Keyless]
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password not matching")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
   
    }
}
