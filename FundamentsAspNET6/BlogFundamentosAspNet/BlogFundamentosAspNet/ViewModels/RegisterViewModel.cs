using System.ComponentModel.DataAnnotations;

namespace BlogFundamentosAspNet.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email é inválido.")]
    public string Email { get; set; }
}