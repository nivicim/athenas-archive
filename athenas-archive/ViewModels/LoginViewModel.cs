using System.ComponentModel.DataAnnotations;
namespace athenas_archive.ViewModels
{
    

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
