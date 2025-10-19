using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiApp1.Models;
namespace MauiApp1.Data
{

    namespace ColetixApp.Data
    {
        public class DatabaseService
        {
            private readonly SQLiteAsyncConnection _database;

            public DatabaseService(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Usuario>().Wait();
            }

            public Task<List<Usuario>> GetUsuariosAsync() =>
                _database.Table<Usuario>().ToListAsync();

            public Task<Usuario> GetUsuarioAsync(string usuarioNome) =>
                _database.Table<Usuario>()
                         .Where(u => u.UsuarioNome == usuarioNome)
                         .FirstOrDefaultAsync();

            // Método seguro para salvar usuário — checa duplicado e trata exceções
            public async Task<int> SaveUsuarioAsync(Usuario usuario)
            {
                if (usuario == null)
                    throw new ArgumentNullException(nameof(usuario));

                // checar campos obrigatórios
                if (string.IsNullOrWhiteSpace(usuario.UsuarioNome))
                    throw new ArgumentException("UsuarioNome é obrigatório.", nameof(usuario.UsuarioNome));

                try
                {
                    // checar duplicado pelo campo único
                    var existente = await GetUsuarioAsync(usuario.UsuarioNome);
                    if (existente != null)
                    {
                        // Retornar zero ou lançar — aqui vamos lançar para informar ao chamador
                        throw new InvalidOperationException("Usuário já existe.");
                    }

                    // Inserir
                    return await _database.InsertAsync(usuario);
                }
                catch (SQLiteException sqlEx)
                {
                    // registra detalhe para debug e lança mensagem amigável
                    System.Diagnostics.Debug.WriteLine($"SQLiteException SaveUsuarioAsync: {sqlEx.Message}");
                    throw; // rethrow para o chamador poder tratar
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Exception SaveUsuarioAsync: {ex.Message}");
                    throw;
                }
            }

            public Task<int> UpdateUsuarioAsync(Usuario usuario) =>
                _database.UpdateAsync(usuario);
        }
    }
}