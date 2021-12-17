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
    public partial class AllCircuitsPage : ContentPage
    {
        public AllCircuitsPage()
        {
            InitializeComponent();

            //Circuits weergeven
            showCircuits();
        }

        private async Task showCircuits()
        {
            //Circuits verkrijgen
            RootObject circuits = await FormulaRepository.GetCircuitsAsync();
            lvwCircuits.ItemsSource = circuits.MRData.CircuitTable.Circuits;
        }

        private void lvwCircuits_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Circuit circuit = lvwCircuits.SelectedItem as Circuit;

            if (circuit != null)
            {
                Navigation.PushAsync(new CircuitDetail(circuit));
            }
        }
    }
}