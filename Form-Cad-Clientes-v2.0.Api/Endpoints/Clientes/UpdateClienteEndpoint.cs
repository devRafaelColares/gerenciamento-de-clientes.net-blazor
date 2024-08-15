using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Formulario.Core.Requests;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Clientes
{
    public class UpdateClienteEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Update Cliente")
                .WithSummary("Atualiza um cliente existente")
                .WithDescription("Atualiza as informações de um cliente no banco de dados")
                .Produces<ClienteResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }

        private static async Task<IResult> HandleAsync(
            long id,
            UpdateClienteRequest request,
            IClienteService clienteService)
        {
            var result = await clienteService.UpdateAsync(id, request);
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.NotFound();
        }
    }
}
