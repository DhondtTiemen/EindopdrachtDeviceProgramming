using Eindopdracht.Models;
using Eindopdracht.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eindopdracht.Views
{
    public partial class AllSeasonsPage : ContentPage
    {
        public AllSeasonsPage()
        {
            InitializeComponent();

            //Seizoenen weergeven
            ShowSeasons();
        }

        private async void ShowSeasons()
        {
            //Seizoenen verkrijgen
            RootObject seizoenen = await FormulaRepository.GetSeasonsAsync();
            lvwSeasons.ItemsSource = seizoenen.MRData.SeasonTable.Seasons;
        }

        private void lvwSeasons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Season season = lvwSeasons.SelectedItem as Season;

            if (season != null)
            {
                int gekozenJaartal = Convert.ToInt32(season.season);

                if (gekozenJaartal >= 2005)
                {
                    Navigation.PushAsync(new CircuitPage(season));
                }
                else
                {
                    Navigation.PushAsync(new CircuitPageWithoutTime(season));
                }
            }
        }
    }
}