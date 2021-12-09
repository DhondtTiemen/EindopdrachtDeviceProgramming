using Eindopdracht.Models;
using Eindopdracht.Repositories;
using Eindopdracht.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Navigation.PushAsync(new AllSeasonsPage());
        }

        private void frameCircuits_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllCircuitsPage());
        }

        private void frameDrivers_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllDriversPage());
        }
    }
}
