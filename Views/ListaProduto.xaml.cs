using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();
		lst_produtos.ItemsSource = lista;
	}
	protected async override void OnAppearing()
	{
		List<Produto> tmp= await App.Db.GetAll();
		tmp.ForEach(i=> lista.Add(i));
	}
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());
		}
		catch(Exception ex)
		{
			DisplayAlert("ops", ex.Message,"ok");
		}

    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";

        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        lst_produtos.IsRefreshing = true;

        lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => lista.Add(i));

    }

    private void lst_produtos_Refreshing(object sender, EventArgs e)
    {

    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}