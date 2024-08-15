using System.Security.Claims;
using Formulario.Api.Interfaces;
using Formulario.Core.Requests;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Clientes
{
    public class CreateClienteEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync)
                .WithName("Create Cliente")
                .WithSummary("Cria um novo cliente")
                .WithDescription("Cria um novo cliente no banco de dados")
                .Produces<ClienteResponse>(StatusCodes.Status201Created);
        }

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IClienteService clienteService,
            CreateClienteRequest request)
        {
            // Não é necessário definir UserId no CreateClienteRequest
            var result = await clienteService.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/v1/clientes/{result.Data?.Codigo}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
