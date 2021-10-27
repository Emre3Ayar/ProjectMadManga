using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMadManga.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavCreatePage : ContentPage
    {
        public NavCreatePage()
        {
            InitializeComponent();
            Resources["HotWheelsStackLayout"] = App.Current.Resources["HotWheelsStackLayoutF"];
            Resources["HotWheelsLabel"] = App.Current.Resources["HotWheelsLabelF"];
            Resources["HotWheelsStackLayout"] = App.Current.Resources["HotWheelsStackLayoutM"];
            Resources["HotWheelsLabel"] = App.Current.Resources["HotWheelsLabelM"];        
        }

        private async void BtnCreate_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new CreatePage());
        }

    }
}