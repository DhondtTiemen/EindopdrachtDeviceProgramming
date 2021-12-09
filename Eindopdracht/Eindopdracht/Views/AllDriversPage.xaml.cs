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
    public partial class AllDriversPage : ContentPage
    {
        public AllDriversPage()
        {
            InitializeComponent();

            //Drivers weergeven
            showDrivers();
        }

        private async Task showDrivers()
        {
            //Drivers verkrijgen
            RootObject drivers = await FormulaRepository.GetDriversAsync();
            lvwCircuits.ItemsSource = drivers.MRData.DriverTable.Drivers;
        }
    }
}