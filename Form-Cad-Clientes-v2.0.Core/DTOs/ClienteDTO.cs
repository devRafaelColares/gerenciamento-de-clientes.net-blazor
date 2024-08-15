namespace Formulario.Core.DTOs
{
    public class ClienteDTO
    {
        public long Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public CidadeDTO Cidade { get; set; } = new CidadeDTO();
    }
}

