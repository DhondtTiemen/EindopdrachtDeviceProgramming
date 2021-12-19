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
    public partial class AllDriversPage : ContentPage
    {
        public AllDriversPage()
        {
            InitializeComponent();

            //Drivers weergeven
            showDrivers();
        }

        private async void showDrivers()
        {
            //Drivers verkrijgen
            RootObject drivers = await FormulaRepository.GetDriversAsync();
            lvwDrivers.ItemsSource = drivers.MRData.DriverTable.Drivers;

            //Favoriete Circuits opvragen
            List<RootObject> favoritesCircuits = await FormulaRepository.GetFavoriteDrivers();
            lvwFavoriteDrivers.ItemsSource = favoritesCircuits;
            lvwFavoriteDrivers.HeightRequest = 50 * favoritesCircuits.Count;
        }

        private void lvwDrivers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Drivers driver = lvwDrivers.SelectedItem as Drivers;

            var test = lvwDrivers.SelectedItem.GetType();

            if (driver != null)
            {
                NetworkAccess current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    Navigation.PushAsync(new DriverDetail(driver));
                }
                else
                {
                    Navigation.PushAsync(new NoInternetPage());
                }
            }
        }
    }
}