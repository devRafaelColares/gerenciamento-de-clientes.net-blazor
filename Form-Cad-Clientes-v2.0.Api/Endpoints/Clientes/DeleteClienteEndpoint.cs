using Formulario.Api.Interfaces;
using Formulario.Api.Services;

namespace Formulario.Api.Endpoints.Clientes
{
    public class DeleteClienteEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("clientes/{id}", HandleAsync)
                .WithName("Delete Cliente")
                .WithSummary("Deleta um cliente")
                .WithDescription("Deleta um cliente do banco de dados")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
        }

        private static async Task<IResult> HandleAsync(long id, IClienteService clienteService)
        {
            var result = await clienteService.DeleteAsync(id);
            return result.IsSuccess ? TypedResults.NoContent() : TypedResults.NotFound();
        }
    }
}
