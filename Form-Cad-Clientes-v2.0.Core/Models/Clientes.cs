namespace Formulario.Core.Models;

    class Clientes
    {
        public long Id { get; set;}
        public long Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto {get; set;} = string.Empty;
        public string Sexo {get; set;} = string.Empty;
        public string Cidade {get; set;} = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }