using System.ComponentModel.DataAnnotations;

namespace MauiApp1.DTOs
{
    // Este DTO é usado SOMENTE para enviar credenciais de Login para a API
    public class UsuarioLoginDTO
    {
        // O nome desta propriedade (UsuarioNome) deve ser igual ao que a sua API espera
        public string UsuarioNome { get; set; } = string.Empty;

        // A senha
        public string Senha { get; set; } = string.Empty;
    }
}