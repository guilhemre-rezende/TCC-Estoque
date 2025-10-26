namespace MauiApp1.Views;

public partial class EntradaProdutoPage : ContentPage
{
	public EntradaProdutoPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()  //Mantem a página sempre atualizada de produtos cadastrados
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

    private void RegistrarProduto_Clicked(object sender, EventArgs e)  //Botão para Registrar o produto na página de entrada
    {

    }

    private async void PaginaInicial_Clicked(object sender, EventArgs e) //Botão para voltar à página inicial
    {
        await Navigation.PopAsync();
    }
}