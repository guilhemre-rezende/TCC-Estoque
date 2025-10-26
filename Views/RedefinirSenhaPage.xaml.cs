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

            if (string.IsNullOrEmpty(usuarioNome))
            {
                await DisplayAlert("Aten��o", "Informe o Email de usu�rio", "OK");
                return;
            }

            await DisplayAlert("Sucesso", $"Uma senha tempor�ria foi enviada para o e-mail de {usuarioNome}.", "OK");

            entryUsuario.Text = string.Empty;

        }


        private async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
