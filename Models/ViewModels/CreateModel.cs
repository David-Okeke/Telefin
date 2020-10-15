using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models.ViewModels
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}