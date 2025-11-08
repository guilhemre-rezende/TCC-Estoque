using Microsoft.Extensions.Logging;
using MauiApp1.Services;
using MauiApp1.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

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

            // URL de base para o Android (10.0.2.2 é o IP do host)
            const string BaseUrl = "http://10.0.2.2:5299";

            // --- REGISTRO DE SERVIÇOS PARA INJEÇÃO DE DEPENDÊNCIA ---

            // CORREÇÃO CRÍTICA: Registra o AuthService e configura seu HttpClient
            // O AddHttpClient garante que o BaseAddress seja setado ANTES de ser injetado no construtor do AuthService.
            builder.Services.AddHttpClient<AuthService>(client =>
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(5); // Timeout para evitar esperas longas
            });

            // 2. Páginas que usam injeção no construtor
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddTransient<CadastroPage>();
            // Adicione outras páginas que usam injeção aqui (Ex: RedefinirSenhaPage)
            // builder.Services.AddTransient<RedefinirSenhaPage>(); 

            // --------------------------------------------------------

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}