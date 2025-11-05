using TCC_Estoque_API.Data;
using TCC_Estoque_API.DTOs;
using TCC_Estoque_API.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; // Biblioteca nova para o hash de senha

namespace TCC_Estoque_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            // O DbContext vai ser injetado aqui (Injeção de Dependência)
            _context = context;
        }

        public async Task<bool> CadastrarUsuarioAsync(UsuarioCadastroDTO usuarioDto)
        {
            //  Verifica se o nome de usuário ou e-mail já estão em uso.
            bool usuarioExiste = await _context.Usuarios
                .AnyAsync(u => u.UsuarioNome == usuarioDto.UsuarioNome || u.Email == usuarioDto.Email);

            if (usuarioExiste)
            {
                // Se sim, retorna false para o Controller lidar com o erro.
                return false;
            }

            // Cria o hash da senha (CRIPTOGRAFIA CRUCIAL)
            // O BCrypt gera um hash forte e seguro que não pode ser revertido.
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha);

            //  Mapeia o DTO para o Modelo de Banco de Dados
            var novoUsuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Sobrenome = usuarioDto.Sobrenome,
                Email = usuarioDto.Email,
                UsuarioNome = usuarioDto.UsuarioNome,
                SenhaHash = senhaHash // Salva o hash, NUNCA a senha pura!
            };

            // Salva no banco de dados
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}