using System.ComponentModel.DataAnnotations;

namespace Form_Cad_Clientes_v2._0.Web.Models
{
    public class Cliente
    {
        public int Codigo { get; set; } // Id do cliente

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = "";

        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = "";

        public string Foto { get; set; } = "";
        public string Sexo { get; set; } = "";
        public int CidadeId { get; set; } // Referência à cidade
        public Cidade Cidade { get; set; } = new Cidade(); // Objeto Cidade relacionado
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data de criação
        public bool IsSelected { get; set; } // Controle para seleção na UI
    }

    public class Cidade
    {
        public int Id { get; set; } // Id da cidade
        public string Nome { get; set; } = ""; // Nome da cidade
        public string Estado { get; set; } = ""; // Estado da cidade
    }



}
