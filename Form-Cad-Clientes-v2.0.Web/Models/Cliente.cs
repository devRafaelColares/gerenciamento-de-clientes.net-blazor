namespace Form_Cad_Clientes_v2._0.Web.Models
{
    public class Cliente
    {
        public int Codigo { get; set; } // Id do cliente
        public string Nome { get; set; } = "";
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

    public class Distrito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Municipio Municipio { get; set; }
    }

    public class Municipio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
