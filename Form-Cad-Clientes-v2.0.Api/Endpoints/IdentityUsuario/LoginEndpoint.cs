using Formulario.Core.Requests.Usuario;
using Microsoft.AspNetCore.Identity;
using Formulario.Api.Interfaces;
using Formulario.Api.Models;

namespace Formulario.Api.Endpoints.IdentityUsuario
{
    public class LoginEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("identity/login", HandleAsync)
                .AllowAnonymous();
        private async Task<IResult> HandleAsync(
            LoginRequest request,
            SignInManager<Usuario> signInManager,
            HttpContext httpContext)
        {
            var result = await signInManager.PasswordSignInAsync(
                request.UserName,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Results.Ok(new { message = "Login bem-sucedido" });
            }
            else if (result.IsLockedOut)
            {
                return Results.StatusCode(StatusCodes.Status423Locked);
            }
            else
            {
                return Results.BadRequest(new { message = "Credenciais inválidas" });
            }
        }
    }
}
