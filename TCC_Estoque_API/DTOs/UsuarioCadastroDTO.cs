using System.ComponentModel.DataAnnotations;

namespace TCC_Estoque_API.DTOs
{
    // DTOs são usados para receber dados de entrada e ignorar a estrutura do BD
    // Por isso, ele recebe a senha em texto puro aqui.
    public class UsuarioCadastroDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string UsuarioNome { get; set; } = string.Empty; 

        [Required]
        [MinLength(6)]
        public string Senha { get; set; } = string.Empty;   

        [Required]
        [Compare("Senha", ErrorMessage = "Senhas diferentes.")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
