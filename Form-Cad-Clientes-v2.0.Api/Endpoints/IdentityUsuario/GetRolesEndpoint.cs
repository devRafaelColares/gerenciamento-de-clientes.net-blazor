using System.Security.Claims;
using Formulario.Api.Interfaces;
using Formulario.Core.Models.Conta;

namespace Formulario.Api.Endpoints.IdentityUsuario;

public class GetRolesEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
        => app
            .MapGet("identity/roles", Handle)
            .RequireAuthorization();

    private Task<IResult> Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity
            .FindAll(identity.RoleClaimType)
            .Select(c => new RoleClaim
            {
                Issuer = c.Issuer,
                OriginalIssuer = c.OriginalIssuer,
                Type = c.Type,
                Value = c.Value,
                ValueType = c.ValueType
            });

        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
}