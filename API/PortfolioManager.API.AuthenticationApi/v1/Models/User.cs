using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.API.AuthenticationApi.v1.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
