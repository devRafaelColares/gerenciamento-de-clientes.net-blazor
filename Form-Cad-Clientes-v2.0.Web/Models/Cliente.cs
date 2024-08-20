namespace Form_Cad_Clientes_v2._0.Web.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Foto { get; set; } = "";
        public string Sexo { get; set; } = "";
        public Cidade Cidade { get; set; } = new Cidade();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsSelected { get; set; }
    }

    public class Cidade
    {
        public string Nome { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
