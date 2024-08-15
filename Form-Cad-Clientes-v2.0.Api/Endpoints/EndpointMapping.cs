using Formulario.Api.Endpoints.Clientes;
using Formulario.Api.Endpoints.Cidades;
using Formulario.Api.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Formulario.Api.Endpoints
{
    public static class EndpointMapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
                .MapGroup(""); // Grupo de rotas principal

            // Endpoint de saúde
            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            // Endpoints de clientes
            endpoints.MapGroup("v1/clientes")
                .WithTags("Clientes")
                .MapEndpoint<CreateClienteEndpoint>()
                .MapEndpoint<ListClientesEndpoint>()
                .MapEndpoint<GetClienteByIdEndpoint>()
                .MapEndpoint<UpdateClienteEndpoint>()
                .MapEndpoint<DeleteClienteEndpoint>();

            // Endpoints de cidades
            endpoints.MapGroup("v1/cidades")
                .WithTags("Cidades")
                .MapEndpoint<CreateCidadeEndpoint>()
                .MapEndpoint<ListCidadesEndpoint>()
                .MapEndpoint<GetCidadeByIdEndpoint>()
                .MapEndpoint<UpdateCidadeEndpoint>()
                .MapEndpoint<DeleteCidadeEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder builder)
            where TEndpoint : IEndpoint, new()
        {
            var endpoint = new TEndpoint();
            endpoint.Map(builder);
            return builder;
        }
    }
}
