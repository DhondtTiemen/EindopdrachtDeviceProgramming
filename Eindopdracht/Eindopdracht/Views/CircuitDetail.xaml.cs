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
        public bool isFavorite = false;
        public CircuitDetail(Circuit circuit)
        {
            InitializeComponent();

            //Circuit opslaan in object
            circuitGekozen = circuit;

            

            

            //CircuitInfo weergeven
            showCircuit();
        }

        private async void showCircuit()
        {
            string isFav = await FormulaRepository.IsFavorite(circuitGekozen.circuitId);

            if (isFav == "true")
            {
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesFull.png");
                isFavorite = true;
            }
            else
            {
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesEmpty.png");
                isFavorite = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Circuit toevoegen aan favorieten
            //FavoriteCircuit favoriteCircuit = await FormulaRepository.AddFavoriteCircuitAsync(circuitGekozen.circuitId);
        }

        private async void imgFavorite_Clicked(object sender, EventArgs e)
        {
            if (isFavorite)
            {
                isFavorite = false;
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesEmpty.png");
                await FormulaRepository.DeleteFavoriteCircuit(circuitGekozen.circuitId);
            }
            else
            {
                isFavorite = true;
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesFull.png");
                await FormulaRepository.AddFavoriteCircuit(circuitGekozen.circuitId);
            }
        }
    }
}