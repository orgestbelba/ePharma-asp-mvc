using System.ComponentModel.DataAnnotations;

namespace ePharma_asp_mvc.Data.ViewModels
{
    public class LogInViewModel
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email address is required!")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
