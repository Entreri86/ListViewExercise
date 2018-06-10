using ListViewExercise.Models;
using ListViewExercise.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewExercise
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewAirBnb : ContentPage
	{
        private SearchService searchService;
        private List<SearchGroup> searchGroup;

        public ListViewAirBnb()
        {
            searchService = new SearchService();//Iniciamos la clase para la busqueda...

            InitializeComponent();


            FillListView(searchService.GetRecentSearches());
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            FillListView(searchService.GetRecentSearches(e.NewTextValue));//Pasamos al controlador la consulta hecha en la barra de busqueda mediante el evento.
        }       

        private void OnRefreshListView(object sender, EventArgs e)
        {
            FillListView(searchService.GetRecentSearches(searchBar.Text ));
            searchListView.EndRefresh();
        }

        private void OnSearchSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = sender as Search;

            DisplayAlert("Selected" , selected.Location, "OK");
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            //Casteamos primero para obtener el Item del Menu pulsado
            var menuItem = sender as MenuItem;
            //Despues casteamos el objeto a tipo busqueda para obtener los datos de la clase.
            var search = menuItem.CommandParameter as Search;

            searchGroup[0].Remove(search);//Eliminamos de la vista el objeto del evento.

            searchService.DeleteSearch(search.Id);//Eliminamos del controlador el objeto del evento.

        }

        private void FillListView (IEnumerable<Search> searches)
        {
            searchGroup = new List<SearchGroup>
            {
                new SearchGroup ("Busquedas recientes", searches) //Pasamos el enumerable de parametro y añadimos titulo
            };

            searchListView.ItemsSource = searchGroup;
        }

        private void searchListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = sender as Search;

            DisplayAlert("Selected", selected.Location, "OK");
            

        }
    }
}