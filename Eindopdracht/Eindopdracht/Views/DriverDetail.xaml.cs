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
    public partial class DriverDetail : ContentPage
    {
        public Driver driverGekozen { get; set; }
        public bool isFavorite = false;
        public DriverDetail(Driver driver)
        {
            InitializeComponent();

            //Driver opslaan in object
            driverGekozen = driver;

            //Driverinfo weergeven
            showDriver();
        }

        private void showDriver()
        {
            throw new NotImplementedException();
        }

        private void imgFavorite_Clicked(object sender, EventArgs e)
        {

        }
    }
}