namespace MauiApp1.Views;

public partial class SaidaProdutoPage1 : ContentPage
{
    public SaidaProdutoPage1()
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

    private async void SaidaProduto_Clicked(object sender, EventArgs e) //Bot�o para Retirar,  o produto
    {
      
    }

    private async void PaginaInicial_Clicked(object sender, EventArgs e) //Bot�o para voltar � p�gina inicial
    {
        await Navigation.PopAsync();
    }
}