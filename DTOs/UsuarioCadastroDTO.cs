using System.ComponentModel.DataAnnotations;

namespace MauiApp1.DTOs
{
    // Este DTO é usado para enviar dados do MAUI para a API
    public class UsuarioCadastroDTO
    {
        // Os nomes das propriedades  iguais aos da API
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UsuarioNome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}