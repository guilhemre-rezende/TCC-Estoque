using System.ComponentModel.DataAnnotations;

namespace TCC_Estoque_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        // Inicialização para resolver o CS8618
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // Inicializado

        [Required]
        public string UsuarioNome { get; set; } = string.Empty; // Inicializado

        [Required]
        public string SenhaHash { get; set; } = string.Empty; // Inicializado
    }
}
