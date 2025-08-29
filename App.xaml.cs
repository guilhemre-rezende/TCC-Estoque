using MauiApp1.Helpers;

namespace MauiApp1
{
    public partial class App : Application
    {
        static Sqlite_databaseHelper _db;

        public static Sqlite_databaseHelper Db {  get
            {
                if (_db ==null)
                {
                    string path = Path.Combine(
                      Environment.GetFolderPath(
                          Environment.SpecialFolder.LocalApplicationData),
                      "banco_sqlite_compras.db3");

                    _db = new Sqlite_databaseHelper(path);

                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();    
            MainPage = new NavigationPage( new Views.ListaProduto());
        }
    }
}
