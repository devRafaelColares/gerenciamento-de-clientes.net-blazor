using Formulario.Core;
using Formulario.Core.DTOs;
using Formulario.Core.Requests;
using Formulario.Core.Requests.Clientes;


namespace Formulario.Api.Interfaces
{
    public interface IClienteService
    {
        Task<Response<ClienteDTO?>> CreateAsync(CreateClienteRequest request);
        Task<Response<List<ClienteDTO>>> GetAllAsync();
        Task<Response<ClienteDTO?>> GetByIdAsync(long id);
        Task<Response<ClienteDTO?>> UpdateAsync(long id, UpdateClienteRequest request);
        Task<Response<bool>> DeleteAsync(long id);
    }
}
