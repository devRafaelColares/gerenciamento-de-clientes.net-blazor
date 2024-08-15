using Formulario.Api.Interfaces;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Cidades
{
    public class GetCidadeByIdEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("cidades/{id}", HandleAsync)
                .WithName("Get Cidade By Id")
                .WithSummary("Retorna uma cidade específica")
                .Produces<CidadeDetalhesResponse>();
        }

        private static async Task<IResult> HandleAsync(long id, ICidadeService cidadeService)
        {
            var result = await cidadeService.GetByIdAsync(id);
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.NotFound();
        }
    }
}
