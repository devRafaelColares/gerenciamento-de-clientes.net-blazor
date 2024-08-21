namespace Formulario.Core.Requests
{
    public class UpdateClienteRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public CreateCidadeRequest Cidade { get; set; } = new CreateCidadeRequest();
    }
}
