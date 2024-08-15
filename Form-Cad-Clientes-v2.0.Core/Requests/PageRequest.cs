using Formulario.Core.Requests.Usuario;

namespace Dima.Core.Requests
{
    public abstract class PagedRequest : UsuarioRequest
    {
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
    }
}
