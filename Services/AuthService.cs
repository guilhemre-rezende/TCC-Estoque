using MauiApp1.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    // Interface para injeção de dependência
    public interface IAuthService
    {
        Task<string> FazerLoginAsync(UsuarioLoginDTO loginDto);
        Task<bool> CadastrarUsuarioAsync(UsuarioCadastroDTO cadastroDto);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        // CORREÇÃO: Removida a barra final para BaseUrl.
        // Endereço IP 10.0.2.2 é para o emulador Android. Ajuste a porta (5000) se for diferente.
        private const string BaseUrl = "http://10.0.2.2:5299";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Configura a BaseAddress (CRUCIAL)
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(BaseUrl);
            }
        }

        // --- Método de LOGIN ---
        public async Task<string> FazerLoginAsync(UsuarioLoginDTO loginDto)
        {
            try
            {
                // Endpoint agora será BaseUrl + /api/Auth/login 
                var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginDto);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Tenta desserializar e extrair o token
                    var result = JsonDocument.Parse(content);
                    if (result.RootElement.TryGetProperty("token", out var tokenElement))
                    {
                        return tokenElement.GetString() ?? string.Empty;
                    }

                    return string.Empty; // Token não encontrado
                }
                else
                {
                    // Retorna string vazia se o login falhar (ex: 401 Unauthorized)
                    return string.Empty;
                }
            }
            catch (HttpRequestException ex)
            {
                // Lança exceção para ser capturada na LoginPage e exibir a mensagem de erro de CONEXÃO.
                throw new Exception("Falha na comunicação com a API. Verifique a URL e a conexão.", ex);
            }
        }

        // --- Método de CADASTRO ---
        public async Task<bool> CadastrarUsuarioAsync(UsuarioCadastroDTO cadastroDto)
        {
            try
            {
                // Endpoint agora será BaseUrl + /api/Auth/cadastrar
                var response = await _httpClient.PostAsJsonAsync("api/Auth/cadastrar", cadastroDto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Para simplificar, também lança exceção para erro de conexão no cadastro
                throw new Exception("Falha na comunicação com a API de cadastro. Verifique a URL e a conexão.", ex);
            }
        }
    }
}