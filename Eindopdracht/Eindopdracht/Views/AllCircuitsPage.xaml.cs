using Eindopdracht.Models;
using Eindopdracht.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eindopdracht.Views
{
    public partial class AllCircuitsPage : ContentPage
    {
        public AllCircuitsPage()
        {
            InitializeComponent();

            //Circuits weergeven
            showCircuits();
        }

        private async void showCircuits()
        {
            //Circuits opvragen
            RootObject circuits = await FormulaRepository.GetCircuitsAsync();
            lvwCircuits.ItemsSource = circuits.MRData.CircuitTable.Circuits;

            //Favoriete Circuits opvragen
            List<RootObject> favoritesCircuits = await FormulaRepository.GetFavoriteCircuitsAsync();
            lvwFavoritesCircuits.ItemsSource = favoritesCircuits;
            lvwFavoritesCircuits.HeightRequest = 50 * favoritesCircuits.Count;
        }

        private void lvwCircuits_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Circuit circuit = lvwCircuits.SelectedItem as Circuit;

            if (circuit != null)
            {
                NetworkAccess current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    Navigation.PushAsync(new CircuitDetail(circuit));
                }
                else
                {
                    Navigation.PushAsync(new NoInternetPage());
                }
            }
        }
    }
}