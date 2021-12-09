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
    public partial class ResultPage : ContentPage
    {
        public Season seizoensJaar { get; set; }
        public Race seizoensRonde { get; set; }
        public ResultPage(Season seizoen, Race round)
        {
            InitializeComponent();

            //Seizoensjaar opslaan in object
            seizoensJaar = seizoen;
            //Ronde opslaan in object
            seizoensRonde = round;

            showResults();
        }

        private async Task showResults()
        {
            //Resultaten opvragen
            RootObject resultaat = await FormulaRepository.GetResultsByRoundBySeason(seizoensJaar.season, seizoensRonde.round);
            lvwResults.ItemsSource = resultaat.MRData.RaceTable.Races[Convert.ToInt32(seizoensRonde.round) -1].Results;      
        }
    }
}