namespace MauiApp1.Views;

public partial class SaidaProdutoPage1 : ContentPage
{
    public SaidaProdutoPage1()
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

    private async void SaidaProduto_Clicked(object sender, EventArgs e) //Botão para Retirar,  o produto
    {
      
    }

    private async void PaginaInicial_Clicked(object sender, EventArgs e) //Botão para voltar à página inicial
    {
        await Navigation.PopAsync();
    }
}