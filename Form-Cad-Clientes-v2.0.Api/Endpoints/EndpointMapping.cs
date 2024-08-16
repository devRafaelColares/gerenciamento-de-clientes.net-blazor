using Formulario.Api.Endpoints.Clientes;
using Formulario.Api.Endpoints.Cidades;
using Formulario.Api.Interfaces;
using Formulario.Api.Models;
using Formulario.Api.Endpoints.IdentityUsuario;

namespace Formulario.Api.Endpoints
{
    public static class EndpointMapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            var clientesGroup = endpoints.MapGroup("/")
                .WithTags("Clientes");
                // .RequireAuthorization();
            clientesGroup.MapEndpoint<GetClienteByIdEndpoint>();
            clientesGroup.MapEndpoint<ListClientesEndpoint>();
            clientesGroup.MapEndpoint<CreateClienteEndpoint>();
            clientesGroup.MapEndpoint<UpdateClienteEndpoint>();
            clientesGroup.MapEndpoint<DeleteClienteEndpoint>();

            var cidadesGroup = endpoints.MapGroup("/")
                .WithTags("Cidades");
                // .RequireAuthorization();
            cidadesGroup.MapEndpoint<ListCidadesEndpoint>();
            cidadesGroup.MapEndpoint<GetCidadeByIdEndpoint>();
            cidadesGroup.MapEndpoint<CreateCidadeEndpoint>();
            cidadesGroup.MapEndpoint<UpdateCidadeEndpoint>();
            cidadesGroup.MapEndpoint<DeleteCidadeEndpoint>();

            var usuariosGroup = endpoints.MapGroup("/")
                .WithTags("Usuários");
            usuariosGroup.MapEndpoint<LoginEndpoint>();
            usuariosGroup.MapIdentityApi<Usuario>();
            usuariosGroup.MapEndpoint<LogoutEndpoint>();
            usuariosGroup.MapEndpoint<GetRolesEndpoint>();


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
