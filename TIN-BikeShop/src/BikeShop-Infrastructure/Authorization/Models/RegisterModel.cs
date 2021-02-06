using System.ComponentModel.DataAnnotations;

namespace BikeShop_Infrastructure.Authorization.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
