using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }

        private async void BtnCreate_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new CreatePage());
        }

    }
}