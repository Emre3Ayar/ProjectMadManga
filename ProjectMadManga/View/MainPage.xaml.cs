using ProjectMadManga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectMadManga
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Preferences.Clear();
            EntPassword.Text = Preferences.Get("password", "");
            EntGebruikersnaam.Text = Preferences.Get("gebruikersnaam", "");
        }
        
        public string gebruiker;
        private async void LogIn_Clicked(object sender, EventArgs e)
        {

            List<User> gebruikers = await App.Database.GetUsers();
            var resultGebruiker = gebruikers.FirstOrDefault(x => x.UserName == EntGebruikersnaam.Text);
            var resultPassword = gebruikers.FirstOrDefault(x => x.UserPassword == EntPassword.Text);
            //Wachtwoord en gerbuikersnaam controler
            if (resultGebruiker != null && resultPassword != null)
            {
                Preferences.Set("gebruikersnaam", EntGebruikersnaam.Text);
                Preferences.Set("password", EntPassword.Text);
                //navigatie naar MainPage2
                gebruiker = EntGebruikersnaam.Text;
                await this.Navigation.PushAsync(new MainPage2());
            }
            else
            {
                LblMelding.Text = "Verkeerde wachtwoord of user";
            }

        }

        public MainPage(string date)
        {
            InitializeComponent();
            EntGebruikersnaam.Text = date;
        }
    }
}
