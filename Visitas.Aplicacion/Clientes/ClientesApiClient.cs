
using System.Text.Json;
using Visitas.Aplicacion.Dto;

namespace Visitas.Aplicacion.Clientes
{
    public interface IClientesApiClient
    {
        Task<ClienteDto> ObtenerClientePorIdAsync(Guid id);
    }
    public class ClientesApiClient : IClientesApiClient
    {
        private readonly HttpClient _httpClient;
        public ClientesApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClienteDto> ObtenerClientePorIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/Cliente/ObtenerCliente/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("No se pudo obtener el cliente");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var cliente = JsonSerializer.Deserialize<ClienteReponseDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return cliente.Cliente;
        }
    }
}
