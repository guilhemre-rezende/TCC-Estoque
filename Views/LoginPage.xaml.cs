namespace MauiApp1.Views;
using System;
using Microsoft.Maui.Controls;



public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnEntrarClicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text;
        var senha = txtSenha.Text;

        var user = await App.Database.GetUserAsync(usuario, senha);

        if (user != null)
        {
            await DisplayAlert("Sucesso", $"Bem-vindo, {user.Username}!", "OK");
            
            //Voltar para a página inicial
            Application.Current.MainPage = new NavigationPage(new InicialPage());
        }
        else
        {
            await DisplayAlert("Erro", "Usuário ou senha incorretos.", "OK");
        }
    }



    private async void OnCriarContaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroPage());
    }

    private async void OnEsqueceuSenhaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RedefinirSenhaPage());
    }
   
}


