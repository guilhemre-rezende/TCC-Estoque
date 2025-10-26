namespace MauiApp1.Views;
using MauiApp1.Models;


public partial class CadastroProdutoPage : ContentPage
{
	public CadastroProdutoPage()
	{
		InitializeComponent();
	}

    private async void Cadastar_Clicked(object sender, EventArgs e)
    {
        string nome = entryNomeProduto.Text?.Trim();
        string descricao = entryDescricao.Text?.Trim();
        bool quantidadeValida = int.TryParse(entryQuantidade.Text, out int quantidade);
        bool precoValido = double.TryParse(entryPreco.Text, out double preco);

        if (string.IsNullOrEmpty(nome) || !quantidadeValida || !precoValido)
        {
            await DisplayAlert("Atenção", "Preencha todos os campos corretamente.", "OK");
            return;
        }

        var produto = new Produto
        {
            Nome = nome,
            Descricao = descricao,
            Quantidade = quantidade,
            Preco = preco
        };

        await App.Database.SaveProdutoAsync(produto);

        await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

        await Navigation.PopAsync();
    }
    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

