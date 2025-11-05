// TCC_Estoque_API/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TCC_Estoque_API.Models;

namespace TCC_Estoque_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Mapeia a classe Usuario para a tabela "Usuarios" no BD
        public DbSet<Usuario> Usuarios { get; set; }

        // Adicione a classe Produto aqui depois:
        // public DbSet<Produto> Produtos { get; set; } 
    }
}