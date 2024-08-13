namespace Formulario.Core.Models;

    public class Cidades
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public ICollection<Clientes> Clientes { get; set; } = new List<Clientes>(); // Propriedade de navegação
    }
