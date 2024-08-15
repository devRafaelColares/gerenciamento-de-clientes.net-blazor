using Formulario.Api.Interfaces;
using Formulario.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Formulario.Api.Endpoints.IdentityUsuario;

public class LogoutEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
        => app
            .MapPost("identity/logout", HandleAsync)
            .RequireAuthorization();

    private async Task<IResult> HandleAsync(SignInManager<Usuario> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}