using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMadManga.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMycarsPage : ContentPage
    {
        public NavMycarsPage()
        {
            InitializeComponent();
            Resources["HotWheelsStackLayout"] = App.Current.Resources["HotWheelsStackLayoutF"];
            Resources["HotWheelsLabel"] = App.Current.Resources["HotWheelsLabelF"];
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //var m = await App.Database.GetCars();
            //CarLijst.ItemsSource = m;
            CarLijst.ItemsSource = await App.Database.GetCars();
        }
        private async void OnSelectedHotWheels(Object sender, SelectionChangedEventArgs e)
        {
            var myselected = e.CurrentSelection.FirstOrDefault() as Car;
            await this.Navigation.PushAsync(new DetailPage(myselected.CarName, myselected.CarImage, myselected.CarAccel, myselected.CarTopSpeed, myselected.CarWanted, myselected.CarDetail));
        }
    }
}