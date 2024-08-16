using System.ComponentModel.DataAnnotations;
using Formulario.Core.Requests.Usuario;

namespace Formulario.Core.Requests.Account;

public class LoginRequest : UsuarioRequest
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha Inválida")]
    public string Password { get; set; } = string.Empty;
}