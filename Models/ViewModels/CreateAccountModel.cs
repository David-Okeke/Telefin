using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EarlyMan.Models.ViewModels
{
    public class CreateAccountModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }
    }
}