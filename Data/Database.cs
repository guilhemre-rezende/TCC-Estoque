using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiApp1.Models;
namespace MauiApp1.Data
{
  

        public class Database
        {
            readonly SQLiteAsyncConnection _database;

            public Database(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<User>().Wait();
            }

            public Task<List<User>> GetUsersAsync()
            {
                return _database.Table<User>().ToListAsync();
            }

            public Task<int> SaveUserAsync(User user)
            {
                return _database.InsertAsync(user);
            }

            public Task<User> GetUserAsync(string username, string password)
            {
                return _database.Table<User>()
                    .Where(u => u.Username == username && u.Password == password)
                    .FirstOrDefaultAsync();
            }
        }
    }
