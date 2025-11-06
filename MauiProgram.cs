using Microsoft.Extensions.Logging;
using MauiApp1.Services;
using MauiApp1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // --- REGISTRO DE SERVIÇOS PARA INJEÇÃO DE DEPENDÊNCIA ---

            // 1. REGISTRO CHAVE: HttpClient
            // Agora o MAUI sabe como criar um objeto HttpClient, que é injetado no AuthService.
            builder.Services.AddSingleton<HttpClient>();

            // 2. Serviço de Comunicação com a API (Singleton)
            // O AuthService agora consegue o HttpClient injetado.
            builder.Services.AddSingleton<AuthService>();

            // 3. Páginas que usam injeção no construtor
            // A LoginPage precisa ser registrada (usada no App.xaml.cs)
            builder.Services.AddSingleton<LoginPage>();

            // Registramos a página de Cadastro
            builder.Services.AddTransient<CadastroPage>();

            // --------------------------------------------------------

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}