using Eindopdracht.Interfaces;
using Eindopdracht.Models;
using Eindopdracht.Repositories;
using Eindopdracht.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Eindopdracht
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void frameSeasons_Tapped(object sender, EventArgs e)
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                Navigation.PushAsync(new AllSeasonsPage());
            }
            else
            {
                Navigation.PushAsync(new NoInternetPage());
            } 
        }

        private void frameCircuits_Tapped(object sender, EventArgs e)
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                Navigation.PushAsync(new AllCircuitsPage());
            }
            else
            {
                Navigation.PushAsync(new NoInternetPage());
            }
        }

        private void frameDrivers_Tapped(object sender, EventArgs e)
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                Navigation.PushAsync(new AllDriversPage());
            }
            else
            {
                Navigation.PushAsync(new NoInternetPage());
            }
        }
    }
}
