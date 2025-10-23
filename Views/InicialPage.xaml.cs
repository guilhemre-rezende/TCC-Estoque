namespace MauiApp1.Views;

public partial class InicialPage : ContentPage
{
	public InicialPage()
	{
		InitializeComponent();
	}

    private async void BtnCadastroProdutoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroProdutoPage());
    }

    private async void BtnEntradaProdutoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EntradaProdutoPage());
    }

    private async void BtnSaidaProdutoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SaidaProdutoPage1());
    }

    private async void BtnRelatorioPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RelatorioPage1());
    }
}