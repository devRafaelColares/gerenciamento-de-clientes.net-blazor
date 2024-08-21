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
                Console.WriteLine($"Erro ao salvar cliente: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletarCliente(int codigo)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5176/clientes/{codigo}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                return false;
            }
        }

        public async Task<List<string>> GetCidadesByEstado(string UF)
        {
            try
            {
                // Substitua com a URL correta para a API de cidades
                var response = await _httpClient.GetFromJsonAsync<List<Distrito>>($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/distritos");

                // Verifica se a resposta é nula e cria uma lista vazia se necessário
                if (response == null)
                {
                    return new List<string>();
                }

                // Extrai os nomes dos distritos da resposta
                return response.Select(d => d.Nome).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter cidades: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
