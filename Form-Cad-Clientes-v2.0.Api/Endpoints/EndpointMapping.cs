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
                .MapGroup("");

            // Endpoint de saúde
            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            var clientesGroup = endpoints.MapGroup("/")
                .WithTags("Clientes");
            clientesGroup.MapEndpoint<CreateClienteEndpoint>();
            clientesGroup.MapEndpoint<ListClientesEndpoint>();
            clientesGroup.MapEndpoint<GetClienteByIdEndpoint>();
            clientesGroup.MapEndpoint<UpdateClienteEndpoint>();
            clientesGroup.MapEndpoint<DeleteClienteEndpoint>();

            // Endpoints de cidades
            var cidadesGroup = endpoints.MapGroup("/")
                .WithTags("Cidades");
            cidadesGroup.MapEndpoint<CreateCidadeEndpoint>();
            cidadesGroup.MapEndpoint<ListCidadesEndpoint>();
            cidadesGroup.MapEndpoint<GetCidadeByIdEndpoint>();
            cidadesGroup.MapEndpoint<UpdateCidadeEndpoint>();
            cidadesGroup.MapEndpoint<DeleteCidadeEndpoint>();
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
