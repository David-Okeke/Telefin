using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models.ViewModels
{
    public class CreateModel
    {
        [Required(ErrorMessage = "Invalid input")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(".+\\@.+\\..+",
           ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNo { get; set; }
    }
}