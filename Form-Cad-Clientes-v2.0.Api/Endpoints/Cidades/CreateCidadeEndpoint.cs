using Formulario.Api.Services;
using Formulario.Core.Requests;
using Formulario.Api.Interfaces;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Cidades
{
    public class CreateCidadeEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync)
                .WithName("Create Cidade")
                .WithSummary("Cria uma nova cidade")
                .WithDescription("Cria uma nova cidade no banco de dados")
                .Produces<CidadeDetalhesResponse>(StatusCodes.Status201Created);
        }

        private static async Task<IResult> HandleAsync(
            CreateCidadeRequest request,
            ICidadeService cidadeService)
        {
            var result = await cidadeService.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/v1/cidades/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
