using Eindopdracht.Interfaces;
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
    public partial class DriverDetail : ContentPage
    {
        public Drivers driverGekozen { get; set; }
        public bool isFavorite = false;
        public DriverDetail(Drivers driver)
        {
            InitializeComponent();

            //Driver opslaan in object
            driverGekozen = driver;

            //Driverinfo weergeven
            showDriver();
        }

        private async void showDriver()
        {
            string isFav = await FormulaRepository.IsFavoriteDriver(driverGekozen.driverId);

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

        private async void imgFavorite_Clicked(object sender, EventArgs e)
        {
            if (isFavorite)
            {
                isFavorite = false;
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesEmpty.png");
                DependencyService.Get<IToast>().ToastPopUp($"{driverGekozen.givenName} has been deleted from favorites");
                await FormulaRepository.DeleteFavoriteDriver(driverGekozen.driverId);
            }
            else
            {
                isFavorite = true;
                imgFavorite.IconImageSource = ImageSource.FromResource("Eindopdracht.Assets.FavoritesFull.png");
                DependencyService.Get<IToast>().ToastPopUp($"{driverGekozen.givenName} has been added favorites");
                await FormulaRepository.AddFavoriteDriver(driverGekozen.driverId);
            }
        }
    }
}