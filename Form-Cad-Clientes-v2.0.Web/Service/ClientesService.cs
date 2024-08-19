using System.Net.Http.Json;
using Formulario.Core;

namespace Form_Cad_Clientes_v2._0.Web.Service;

public class ClientesService
{
    private readonly HttpClient _httpClient;

    public ClientesService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Configuration.HttpClient);
    }

    public async Task<Response<string>> GetClientes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Response<string>>("clientes");
            return response ?? new Response<string>(false, null, "Nenhum dado encontrado.", 404);
        }
        catch (Exception ex)
        {
            return new Response<string>(false, null, $"Erro ao obter clientes: {ex.Message}", 500);
        }
    }
}
