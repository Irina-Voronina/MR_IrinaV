using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MR_IrinaV
{
    public partial class PopUp_Page : ContentPage
    {
        public PopUp_Page()
        {
            Button alertButton = new Button
            {
                Text = "Teade",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;

            Button alertYesNoButton = new Button
            {
                Text = "Jah vöi ei",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

            Button alertListButton = new Button
            {
                Text = "Valik",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;

            Button alertQuestButton = new Button
            {
                Text = "Küsimus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestButton.Clicked += AlertQuestButton_Clicked;


            Content = new StackLayout { Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton } };
        }
    

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teade", "Teil on uus teade", "OK");
        }
        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            
            var action = await DisplayActionSheet("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");
            
        }

        private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");
            await DisplayAlert("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");
        }

        private async void AlertQuestButton_Clicked(object sender, EventArgs e)
        {
            string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
            string result2 = await DisplayPromptAsync("Vasta", "Millega vördub 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
        }


    }
}