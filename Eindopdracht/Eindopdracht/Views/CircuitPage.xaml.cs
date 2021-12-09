using Eindopdracht.Models;
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
        }
    }
}