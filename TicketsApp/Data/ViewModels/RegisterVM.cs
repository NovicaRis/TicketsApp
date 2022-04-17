using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage ="Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
