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
    public partial class CircuitDetail : ContentPage
    {
        public Circuit circuitGekozen { get; set; }
        public CircuitDetail(Circuit circuit)
        {
            InitializeComponent();

            //Circuit opslaan in object
            circuitGekozen = circuit;

            //CircuitInfo weergeven
            showCircuit();
        }

        private void showCircuit()
        {
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Circuit toevoegen aan favorieten
            //Circuit circuit = await FormulaRepository.AddFavoriteCircuitAsync(circuitGekozen.circuitId);
        }
    }
}