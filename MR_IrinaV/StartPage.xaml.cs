using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new Entry_Page(), new Timer_Page(), new BoxView_Page(), new Valgusfoor_Page(), new DateTime_Page(), new StepperSlider_Page(), new Lumememm_Page(), new Frame_Page() }; // index= 0,1,2,...
        List<string> tekstid = new List<string> { "Ava entry leht", "Ava timer leht", "Ava box leht", "Ava frame leht" };
        public StartPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.MistyRose
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.SpringGreen,
                    TextColor = Color.DarkOrange
                };
                st.Children.Add(button);
                button.Clicked += Navig_funktsion;
            }
            Content = st;
        }
        private async void Navig_funktsion(object sender, EventArgs e)
        {
            Button btn = sender as Button; //(Button)sender
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }

}

     

    
