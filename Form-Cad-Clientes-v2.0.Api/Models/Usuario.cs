using Microsoft.AspNetCore.Identity;

namespace Formulario.Api.Models;

public class Usuario : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}