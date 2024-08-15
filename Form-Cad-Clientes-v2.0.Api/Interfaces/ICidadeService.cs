using Formulario.Core.Requests;
using Formulario.Core.Responses;
using Formulario.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formulario.Core;

namespace Formulario.Api.Interfaces
{
    public interface ICidadeService
    {
        Task<Response<CidadeDetalhesResponse?>> CreateAsync(CreateCidadeRequest request);

        Task<Response<Cidades?>> UpdateAsync(long id, UpdateCidadeRequest request);

        Task<Response<bool>> DeleteAsync(long id);

        Task<Response<CidadeDetalhesResponse?>> GetByIdAsync(long id);

        Task<Response<List<CidadeDetalhesResponse>>> GetAllAsync();
    }
}
