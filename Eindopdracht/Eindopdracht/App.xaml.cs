using Eindopdracht.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eindopdracht
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Red,
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
