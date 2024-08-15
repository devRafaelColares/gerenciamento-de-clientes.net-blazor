using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Formulario.Api.Interfaces
{
    public interface IEndpoint
    {
        void Map(IEndpointRouteBuilder app);
    }
}
