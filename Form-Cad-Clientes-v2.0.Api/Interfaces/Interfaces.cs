
namespace Formulario.Api.Interfaces;

public interface IClienteResponse
{
    long Codigo { get; set; }
    string Nome { get; set; }
    string Telefone { get; set; }
    string Foto { get; set; }
    string Sexo { get; set; }
    DateTime CreatedAt { get; set; }
}

public interface ICidadeResponse
{
    long Id { get; set; }
    string Nome { get; set; }
    string Estado { get; set; }
}

public interface ICidadeDetalhesResponse : ICidadeResponse
{
    List<IClienteResponse> Clientes { get; set; }
}

public class ClienteResponse : IClienteResponse
{
    public long Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class CidadeResponse : ICidadeResponse
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}

public class CidadeDetalhesResponse : CidadeResponse, ICidadeDetalhesResponse
{
    public List<IClienteResponse> Clientes { get; set; } = new List<IClienteResponse>();
}
