using Formulario.Api.Interfaces;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Clientes
{
    public class GetClienteByIdEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("clientes/{id}", HandleAsync)
                .WithName("Get Cliente By Id")
                .WithSummary("Retorna um cliente específico")
                .Produces<ClienteResponse>();
        }

        private static async Task<IResult> HandleAsync(long id, IClienteService clienteService)
        {
            var result = await clienteService.GetByIdAsync(id);
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.NotFound();
        }
    }
}
