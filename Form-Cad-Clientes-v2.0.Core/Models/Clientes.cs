namespace Formulario.Core.Models;

    public class Clientes
    {
        public long Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto {get; set;} = string.Empty;
        public string Sexo {get; set;} = string.Empty;
        public long CidadeId { get; set; } // Chave estrangeira para Cidades
        public Cidades Cidade { get; set; } = null!;// Propriedade de navegação
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }