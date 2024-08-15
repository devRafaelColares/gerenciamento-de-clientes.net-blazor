namespace Formulario.Core.Requests
{
    public class UpdateCidadeRequest
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}