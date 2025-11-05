using TCC_Estoque_API.DTOs;

namespace TCC_Estoque_API.Services
{
    // A interface que define o método que o Controller irá chamar.
    public interface IAuthService
    {
        // Retorna true se o cadastro foi um sucesso, false caso contrário.
        Task<bool> CadastrarUsuarioAsync(UsuarioCadastroDTO usuarioDto);
    }
}
