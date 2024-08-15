namespace Formulario.Core.Responses
{
    public class CidadeDetalhesResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<ClienteResponse> Clientes { get; set; } = new List<ClienteResponse>();
    }
}
