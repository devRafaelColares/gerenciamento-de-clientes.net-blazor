using Formulario.Api.Interfaces;
using Formulario.Api.Services;
using Formulario.Core.Requests;
using Formulario.Core.Responses;

namespace Formulario.Api.Endpoints.Cidades
{
    public class UpdateCidadeEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("cidades/{id}", HandleAsync)
                .WithName("Update Cidade")
                .WithSummary("Atualiza uma cidade existente")
                .WithDescription("Atualiza as informações de uma cidade no banco de dados")
                .Produces<CidadeDetalhesResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }

        private static async Task<IResult> HandleAsync(
            long id,
            UpdateCidadeRequest request,
            ICidadeService cidadeService)
        {
            var result = await cidadeService.UpdateAsync(id, request);
            return result.IsSuccess ? TypedResults.Ok(result.Data) : TypedResults.NotFound();
        }
    }
}
