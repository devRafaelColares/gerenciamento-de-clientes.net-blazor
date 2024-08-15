using Formulario.Api.Interfaces;
using Formulario.Api.Services;

namespace Formulario.Api.Endpoints.Cidades
{
    public class DeleteCidadeEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("cidades/{id}", HandleAsync)
                .WithName("Delete Cidade")
                .WithSummary("Deleta uma cidade")
                .WithDescription("Deleta uma cidade do banco de dados")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
        }

        private static async Task<IResult> HandleAsync(long id, ICidadeService cidadeService)
        {
            var result = await cidadeService.DeleteAsync(id);
            return result.IsSuccess ? TypedResults.NoContent() : TypedResults.NotFound();
        }
    }
}
