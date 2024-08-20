using System.Net.Http.Json;
using Formulario.Core.Models;

namespace Form_Cad_Clientes_v2._0.Web.Service
{
    public class ClientesService
    {
        private readonly HttpClient _httpClient;

        public ClientesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HttpClientName");
        }

        public async Task<List<Clientes>> GetClientes()
        {
            try
            {
                var clientes = await _httpClient.GetFromJsonAsync<List<Clientes>>("http://localhost:5176/clientes");
                return clientes ?? new List<Clientes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter clientes: {ex.Message}");
                return new List<Clientes>();
            }
        }

        public async Task<bool> SalvarCliente(Clientes cliente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5176/clientes", cliente);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o cliente: {ex.Message}");
                return false;
            }
        }
    }
}
