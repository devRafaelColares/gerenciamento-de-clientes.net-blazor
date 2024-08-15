public class CreateClienteRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public CidadeRequest Cidade { get; set; } = null!;// Adicionando Cidade
}

public class CidadeRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
