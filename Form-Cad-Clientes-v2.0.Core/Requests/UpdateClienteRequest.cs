namespace Formulario.Core.Requests
{
    public class UpdateClienteRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty; // URL ou caminho da foto
        public string Sexo { get; set; } = string.Empty;
        public long CidadeId { get; set; } // ID da cidade relacionada
    }
}
