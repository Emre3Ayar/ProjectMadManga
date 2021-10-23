using ProjectMadManga.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMadManga
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
 
        public CreatePage()
        {
            InitializeComponent();
        }
        async void Create_Clicked(object sender, System.EventArgs e)
        {
            //Waardes voor HotWheels ophalen
            var afbeelding = EntCarName.Text;
            var Naam = EntCarName.Text;
            var Accel = double.Parse(EntCarAccel.Text);
            var Braking = double.Parse(EntCarBraking.Text);
            var Wanted = double.Parse(EntCarWanted.Text);
            var Handeling = double.Parse(EntCarHandeling.Text);
            var TopSpeed = double.Parse(EntCarTopSpeed.Text);
            //Nieuwe HotWheels declareren

            if (await App.Database.NameControl(EntCarName.Text) == 0)
            {
                LblMelding.TextColor = Color.Red;
                LblMelding.Text = "Voertuig bestaat al";
            }
            else
            {
                LblMelding.TextColor = Color.Green;
                LblMelding.Text = "Succes";
                await App.Database.SaveCar(new Car
                {
                    CarName = Naam,
                    CarAccel = Accel,
                    CarBraking = Braking,
                    CarHandeling = Handeling,
                    CarImage = afbeelding,
                    CarTopSpeed = TopSpeed,
                    CarWanted = Wanted
                });
                //string OutputLine = $""
                //Leeg maken velden
                EntCarName.Text = string.Empty;
                EntCarAccel.Text = string.Empty;
                EntCarBraking.Text = string.Empty;
                EntCarWanted.Text = string.Empty;
                EntCarHandeling.Text = string.Empty;
                EntCarTopSpeed.Text = string.Empty;
                //await this.Navigation.PopAsync();
            }
        }          
    }
}