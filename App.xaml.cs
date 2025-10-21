using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MauiApp1.Data;
using MauiApp1.Views;

using MauiApp1.Data;

namespace MauiApp1;

public partial class App : Application
{
    static Database database;

    public static Database Database
    {
        get
        {
            if (database == null)
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "users.db3");

                database = new Database(dbPath);
            }
            return database;
        }
    }

    public App()
    {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.LoginPage());
    }
}
