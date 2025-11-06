using MauiApp1.Views; // Importa todas as Views da sua pasta

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // --- REGISTRO DE ROTAS (Nomes de Classe Confirmados) ---

            // Rotas de Autenticação
            Routing.RegisterRoute(nameof(CadastroPage), typeof(CadastroPage));
            Routing.RegisterRoute(nameof(RedefinirSenhaPage), typeof(RedefinirSenhaPage));

            // Rotas Principais/Navegação
            Routing.RegisterRoute(nameof(InicialPage), typeof(InicialPage));

            // Rotas de Produto/Estoque
            Routing.RegisterRoute(nameof(CadastroProdutoPage), typeof(CadastroProdutoPage));
            Routing.RegisterRoute(nameof(EntradaProdutoPage), typeof(EntradaProdutoPage));
            Routing.RegisterRoute(nameof(SaidaProdutoPage1), typeof(SaidaProdutoPage1));

            // Rotas de Relatório
            Routing.RegisterRoute(nameof(RelatorioPage1), typeof(RelatorioPage1));

            // ----------------------------------------------------
        }
    }
}