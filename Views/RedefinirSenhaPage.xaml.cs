using System;
using Microsoft.Maui.Controls;
using MauiApp1.Data;

namespace MauiApp1.Views
{
    public partial class RedefinirSenhaPage : ContentPage
    {
        public RedefinirSenhaPage()
        {
            InitializeComponent();
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            string usuarioNome = entryUsuario.Text?.Trim();
            string nome = entryNome.Text?.Trim();
            string sobrenome = entrySobrenome.Text?.Trim();
            string novaSenha = entryNovaSenha.Text ?? string.Empty;
            string confirmar = entryConfirmar.Text ?? string.Empty;

            if (string.IsNullOrEmpty(usuarioNome) || string.IsNullOrEmpty(novaSenha))
            {
                await DisplayAlert("Atenção", "Preencha usuário e nova senha.", "OK");
                return;
            }

        

           

            if (novaSenha != confirmar)
            {
                await DisplayAlert("Erro", "As senhas não coincidem.", "OK");
                return;
            }

        }

        private async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
