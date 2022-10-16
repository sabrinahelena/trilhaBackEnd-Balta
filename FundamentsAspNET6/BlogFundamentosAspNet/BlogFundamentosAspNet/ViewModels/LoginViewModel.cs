using System.ComponentModel.DataAnnotations;

namespace BlogFundamentosAspNet.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
