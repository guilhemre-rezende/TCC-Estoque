using MauiApp1.DTOs;
using MauiApp1.Services;
using Microsoft.Maui.Controls;
using System;

namespace MauiApp1.Views
{
    // A página agora recebe o AuthService via Injeção de Dependência
    public partial class CadastroPage : ContentPage
    {
        private readonly AuthService _authService;

        // O construtor é injetado, exigindo a atualização do MauiProgram.cs
        public CadastroPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            // Validação de campos vazios
            if (string.IsNullOrWhiteSpace(entryNome.Text) ||
                string.IsNullOrWhiteSpace(entrySobrenome.Text) ||
                string.IsNullOrWhiteSpace(entryUsuario.Text) ||
                string.IsNullOrWhiteSpace(entrySenha.Text) ||
                string.IsNullOrWhiteSpace(entryConfirmar.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Validação de senhas
            if (entrySenha.Text != entryConfirmar.Text)
            {
                await DisplayAlert("Erro", "A senha e a confirmação de senha não são iguais.", "OK");
                return;
            }

            // Cria o DTO (Objeto de Transferência de Dados)
            var cadastroDto = new UsuarioCadastroDTO
            {
                Nome = entryNome.Text.Trim(),
                Sobrenome = entrySobrenome.Text.Trim(),
                UsuarioNome = entryUsuario.Text.Trim(),
                Senha = entrySenha.Text
            };

            try
            {
                // Chama o serviço para enviar o DTO para a API
                var sucesso = await _authService.CadastrarUsuarioAsync(cadastroDto);

                if (sucesso)
                {
                    await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");
                    // Redireciona para a página de Login (assumindo que LoginPage está registrada)
                    await Shell.Current.GoToAsync("//LoginPage");
                }
                else
                {
                    // Caso o serviço retorne false (email ou usuário já existe)
                    await DisplayAlert("Erro de Cadastro", "Não foi possível completar o cadastro. O nome de usuário/email pode já estar em uso ou a API retornou um erro.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Erro de conexão, API offline, etc.
                await DisplayAlert("Erro de Conexão/API", $"Detalhes: {ex.Message}. Verifique se a API está rodando e se a BaseUrl no AuthService.cs está correta.", "OK");
            }
        }

        private async void Voltar_Clicked(object sender, EventArgs e)
        {
            // Volta para a página anterior
            await Shell.Current.GoToAsync("..");
        }
    }
}

