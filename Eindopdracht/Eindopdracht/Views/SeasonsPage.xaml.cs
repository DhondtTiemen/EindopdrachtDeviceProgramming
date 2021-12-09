using Eindopdracht.Models;
using Eindopdracht.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eindopdracht.Views
{
    public partial class SeasonPage : ContentPage
    {
        public SeasonPage()
        {
            InitializeComponent();

            //Seizoenen weergeven
            ShowSeasons();
        }

        private async Task ShowSeasons()
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
                Navigation.PushAsync(new CircuitPage(season));
            }
        }
    }
}