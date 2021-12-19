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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircuitPageWithoutTime : ContentPage
    {
        public Season seizoenJaar { get; set; }
        public CircuitPageWithoutTime(Season seizoen)
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
                Navigation.PushAsync(new ResultPage(seizoenJaar, race));
            }
        }
    }
}