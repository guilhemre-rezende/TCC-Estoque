using SQLitePCL;
using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
            Produto p = new Produto
            {
                Descricao = txtDescricao.Text,
                Quantidade = Convert.ToDouble(txtQuantidade.Text),
                preco = Convert.ToDouble(txtPreco.Text)
            };

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
            await Navigation.PopAsync();
        }
		catch(Exception ex)
		{
			DisplayAlert("ops", ex.Message, "ok");
		}
    }
}