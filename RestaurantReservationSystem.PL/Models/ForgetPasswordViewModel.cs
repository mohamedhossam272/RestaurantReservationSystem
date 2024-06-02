using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationSystem.PL.Models
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
