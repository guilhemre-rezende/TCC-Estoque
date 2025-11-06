using MauiApp1.DTOs;
using MauiApp1.Services;
using Microsoft.Maui.Controls;
using System;

namespace MauiApp1.Views
{
    // A página agora recebe o AuthService via Injeção de Dependência
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        // Construtor injetado: o MAUI fornece o AuthService, resolvendo o erro CS7036
        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            // Validação de campos vazios (usando os nomes CORRETOS do XAML: txtUsuario e txtSenha)
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha o usuário e a senha.", "OK");
                return;
            }

            var loginDto = new UsuarioLoginDTO
            {
                // Usando os nomes CORRETOS do XAML
                UsuarioNome = txtUsuario.Text.Trim(),
                Senha = txtSenha.Text
            };

            try
            {
                // Chama o serviço para tentar o login na API
                var token = await _authService.FazerLoginAsync(loginDto);

                if (!string.IsNullOrEmpty(token))
                {
                    // Login bem-sucedido
                    await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");

                    // Redireciona para a InicialPage (Rota Shell)
                    await Shell.Current.GoToAsync("//InicialPage");
                }
                else
                {
                    // Credenciais inválidas
                    await DisplayAlert("Erro", "Usuário ou senha incorretos.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Erro de conexão ou da API
                await DisplayAlert("Erro de Conexão/API", $"Detalhes: {ex.Message}. Verifique se a API está rodando e se a BaseUrl está correta.", "OK");
            }
        }

        private async void OnCriarContaClicked(object sender, EventArgs e)
        {
            // Navega para a página de Cadastro usando a rota Shell 
            await Shell.Current.GoToAsync(nameof(CadastroPage));
        }

        private async void OnEsqueceuSenhaClicked(object sender, EventArgs e)
        {
            // Navega para a página de Redefinir Senha
            await Shell.Current.GoToAsync(nameof(RedefinirSenhaPage));
        }
    }
}