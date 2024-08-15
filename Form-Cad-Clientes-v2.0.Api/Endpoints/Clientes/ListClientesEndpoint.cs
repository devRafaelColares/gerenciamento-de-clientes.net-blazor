using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Clientes
{
    public class ListClientesEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync)
                .WithName("List Clientes")
                .WithSummary("Retorna a lista de clientes")
                .Produces<List<ClienteResponse>>();
        }

        private static async Task<IResult> HandleAsync(IClienteService clienteService)
        {
            var result = await clienteService.GetAllAsync();
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.BadRequest(result);
        }
    }
}
