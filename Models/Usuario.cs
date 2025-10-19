using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MauiApp1.Models


{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string UsuarioNome { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
    }
}

