using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxView_Page : ContentPage
    {
        public BoxView_Page()
        {
            BoxView box;
            public BoxView_Page()
            {
                box = new BoxView
                {
                    Color = Color.FromRgb(0, 0, 0),
                    CornerRadius = 15,
                    WidthRequest = 100,
                    HeightRequest = 200,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                box.GestureRecognizers.Add(tap);

                StackLayout st = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { box }
                };
                Content = st;
            }
            Random rnd;
            private void Tap_Tapped(object sender, EventArgs e)
            {
                rnd = new Random();
                box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                box.WidthRequest = box.WidthRequest + 30;
                box.HeightRequest = box.HeightRequest + 30;

                if (box.WidthRequest > 200 && box.HeightRequest > 200)
                {
                    box.WidthRequest = 200; //перевернется горизонтально
                    box.HeightRequest = 100;
                    //box.CornerRadius = 500;

                    //box.WidthRequest = 100;
                    //box.HeightRequest = 200;

                }
                //else
                //{
                //box.WidthRequest = box.WidthRequest + 30;
                //box.HeightRequest = box.HeightRequest + 30;

                //}
            }
        }
    }
}