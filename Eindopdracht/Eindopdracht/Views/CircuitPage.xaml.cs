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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircuitPage : ContentPage
    {
        public Season seizoenJaar { get; set; }
        public CircuitPage(Season seizoen)
        {
            InitializeComponent();

            //Seizoen opslaan in object
            seizoenJaar = seizoen;

            //Circuits per jaar weergeven
            showCircuits();
        }

        private async Task showCircuits()
        {
            //Circuits opvragen
            RootObject circuits = await FormulaRepository.GetCircuitsBySeason(seizoenJaar.season);
            lvwCircuits.ItemsSource = circuits.MRData.RaceTable.Races;
        }

        private void lvwCircuits_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Race race = lvwCircuits.SelectedItem as Race;

            if (race != null)
            {
                NetworkAccess current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    Navigation.PushAsync(new ResultPage(seizoenJaar, race));
                }
                else
                {
                    Navigation.PushAsync(new NoInternetPage());
                }
            }
        }
    }
}