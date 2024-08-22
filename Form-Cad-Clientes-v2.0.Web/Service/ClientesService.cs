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

        public async Task<List<Cidade>> GetCidades()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Distrito>>("https://servicodados.ibge.gov.br/api/v1/localidades/distritos");

                if (response == null)
                {
                    return new List<Cidade>();
                }

                return response.Select(d => new Cidade
                {
                    Id = d.Municipio.Id,
                    Nome = d.Nome,
                    Estado = d.Municipio.Microrregiao.Mesorregiao.UF.Sigla
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter cidades: {ex.Message}");
                return new List<Cidade>();
            }
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"http://localhost:5176/clientes/{cliente.Codigo}", cliente);
                
                response.EnsureSuccessStatusCode();
                
                Console.WriteLine("Cliente atualizado com sucesso!");
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Erro na requisição HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
            }
        }


    }
}
