using Eindopdracht.Models;
using Eindopdracht.Repositories;
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
            ShowSeasons();
        }

        private async Task ShowSeasons()
        {
            //Seizoenen verkrijgen
            RootObject seizoenen = await FormulaRepository.GetSeasonsAsync();
            lvwSeasons.ItemsSource = seizoenen.MRData.SeasonTable.Seasons;
        }
    }
}
