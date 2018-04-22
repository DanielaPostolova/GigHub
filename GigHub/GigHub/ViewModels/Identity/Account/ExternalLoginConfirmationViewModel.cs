using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels.Identity.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}