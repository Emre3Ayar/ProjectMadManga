using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMadManga
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string CarName,string CarImage,double CarAccel,double CarTopSpeed,double CarWanted, string CarDetail)
        {
            InitializeComponent();
            LblAccel.Text = "Acceleratie: ";
            LblTopSpeed.Text = "Topsnelheid: ";
            LblWanted.Text = "Wanted Level: ";
            //Data set to elements
            ImgAfbeelding.Source += CarImage;
            LblNaam.Text += CarName;
            LblAccel.Text += CarAccel.ToString();
            LblTopSpeed.Text += CarTopSpeed.ToString();
            LblWanted.Text += CarWanted.ToString();

            LblDetail.Text = CarDetail;

            //Accel
            if (CarAccel >= 1.8)
            {
                LblAccel.TextColor = Color.Green;
                LblAccel.Text += " Sterk";
            }
            else if (CarAccel >= 1.5)
            {
                LblAccel.TextColor = Color.Orange;
                LblAccel.Text += " Normaal";
            }
            else if (CarAccel < 1.5)
            {
                LblAccel.TextColor = Color.Red;
                LblAccel.Text += " Zwak";
            }
            //TopSpeed
            if (CarTopSpeed >= 110)
            {
                LblTopSpeed.TextColor = Color.Green;
                LblTopSpeed.Text += " Sterk";
            }
            else if (CarTopSpeed >= 45)
            {
                LblTopSpeed.TextColor = Color.Orange;
                LblTopSpeed.Text += " Normaal";
            }
            else if (CarTopSpeed < 45)
            {
                LblTopSpeed.TextColor = Color.Red;
                LblTopSpeed.Text += " Zwak";
            }
            //Wanted
            if (CarWanted >= 7)
            {
                LblWanted.TextColor = Color.Red;
                LblWanted.Text += " Wanted";
            }
            else if (CarWanted >= 2)
            {
                LblWanted.TextColor = Color.Orange;
                LblWanted.Text += " Target";
            }
            else if (CarWanted < 2)
            {
                LblWanted.TextColor = Color.Green;
                LblWanted.Text += " Suspect";
            }
        }
        async void Delete_Event(object sender, EventArgs args)
        {
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {LblNaam.Text}?", "Yes", "No"))
            {
                await App.Database.DeleteCar(LblNaam.Text);
            }          
            await this.Navigation.PopAsync();
        }
    }
}