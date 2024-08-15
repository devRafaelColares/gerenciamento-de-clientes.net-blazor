using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Cidades
{
    public class ListCidadesEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("cidades/", HandleAsync)
                .WithName("List Cidades")
                .WithSummary("Retorna a lista de cidades")
                .Produces<List<CidadeDetalhesResponse>>();
        }

        private static async Task<IResult> HandleAsync(ICidadeService cidadeService)
        {
            var result = await cidadeService.GetAllAsync();
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.BadRequest(result);
        }
    }
}
