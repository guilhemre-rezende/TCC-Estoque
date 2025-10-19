namespace MauiApp1.Views;

using System;
using Microsoft.Maui.Controls;
using MauiApp1.Models;
using MauiApp1.Data;
using SQLite;

    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
        }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        var novoUsuario = new Usuario
        {
            Nome = entryNome.Text?.Trim(),
            Sobrenome = entrySobrenome.Text?.Trim(),
            UsuarioNome = entryUsuario.Text?.Trim(),
            Senha = entrySenha.Text // em produção: hash + salt
        };

        try
        {
         
           
        }
        catch (InvalidOperationException ex) // por exemplo: usuário já existe
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
        catch (SQLiteException sqlEx)
        {
            // Mostra a mensagem do SQLite (útil pra debug)
            await DisplayAlert("Erro no banco", sqlEx.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro inesperado", ex.Message, "OK");
        }
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
