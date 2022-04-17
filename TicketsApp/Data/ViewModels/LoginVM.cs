using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email address is required")]
        [Display(Name ="Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
    }
}
