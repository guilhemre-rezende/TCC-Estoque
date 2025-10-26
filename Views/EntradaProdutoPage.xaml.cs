namespace MauiApp1.Views;

public partial class EntradaProdutoPage : ContentPage
{
	public EntradaProdutoPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()  //Mantem a p�gina sempre atualizada de produtos cadastrados
    {
        base.OnAppearing();
        await CarregarProdutos();
    }
    private async Task CarregarProdutos()
    {
        var produtos = await App.Database.GetProdutosAsync();
        pickerprodutos.ItemsSource = produtos;
    }
    private void EscolhaProduto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void RegistrarProduto_Clicked(object sender, EventArgs e)  //Bot�o para Registrar o produto na p�gina de entrada
    {

    }

    private async void PaginaInicial_Clicked(object sender, EventArgs e) //Bot�o para voltar � p�gina inicial
    {
        await Navigation.PopAsync();
    }
}