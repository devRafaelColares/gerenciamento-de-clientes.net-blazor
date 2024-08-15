using Formulario.Core;
using Formulario.Core.Models;
using Formulario.Core.Requests;
using Formulario.Core.Responses;

namespace Formulario.Api.Interfaces
{
    public interface IClienteService
    {
        Task<Response<Clientes?>> CreateAsync(CreateClienteRequest request);
        Task<Response<List<Clientes>>> GetAllAsync();
        Task<Response<Clientes?>> GetByIdAsync(long id);
        Task<Response<Clientes?>> UpdateAsync(long id, UpdateClienteRequest request);
        Task<Response<bool>> DeleteAsync(long id);
    }
}
