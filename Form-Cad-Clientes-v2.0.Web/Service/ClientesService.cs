using System.Net.Http.Json;
using Form_Cad_Clientes_v2._0.Web.Models;

namespace Form_Cad_Clientes_v2._0.Web.Service
{
    public class ClientesService
    {
        private readonly HttpClient _httpClient;

        public ClientesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HttpClientName");
        }

        public async Task<List<Cliente>> GetClientes()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cliente>>("http://localhost:5176/clientes") 
                       ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter clientes: {ex.Message}");
                return new List<Cliente>();
            }
        }

        public async Task<bool> SalvarCliente(Cliente cliente)
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

        public async Task DeletarCliente(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"http://localhost:5176/clientes/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o cliente: {ex.Message}");
            }
        }
    }
}
