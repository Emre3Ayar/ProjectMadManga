using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectMadManga
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string gebruiker;
        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            //Wachtwoord en gerbuikersnaam controler
            //var resultGebruiker =  Users.FirstOrDefault(x => x.Gebruikersnaam == EntGebruikersnaam.Text);
            //var resultPassword = Users.FirstOrDefault(x => x.Password == EntPassword.Text);
            //if (resultGebruiker != null && resultPassword != null)
            //{
                //navigatie naar MainPage2
                gebruiker = EntGebruikersnaam.Text;
                await this.Navigation.PushAsync(new MainPage2());
            //}
            //else
            //{
            //    LblMelding.Text = "Verkeerde wachtwoord of user";
            //}
            
        }
        //gebruikerlijts invullen
        //List<User> Users = new List<User>
        //{
        //    new User{ID = 0, Name = "Ayar", FirstName = "Emre", Email = "EmreAyar@gmail.com" , Gebruikersnaam = "Bob", Password = "123", IDCarlist = 1}
        //};

        public MainPage(string date)
        {
            InitializeComponent();
            EntGebruikersnaam.Text = date;
        }
    }
}
