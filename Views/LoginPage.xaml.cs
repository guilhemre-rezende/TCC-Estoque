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
        }
        else
        {
            await DisplayAlert("Erro", "Usuário ou senha incorretos.", "OK");
        }
    }



    private async void OnCriarContaClicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text;
        var senha = txtSenha.Text;

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos!", "OK");
            return;
        }

        await App.Database.SaveUserAsync(new Models.User
        {
            Username = usuario,
            Password = senha
        });

        await DisplayAlert("Sucesso", "Usuário criado!", "OK");
    }
}


