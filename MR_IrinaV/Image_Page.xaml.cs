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
    public partial class Image_Page : ContentPage
    {
        Switch sw;
        Image img;

        public Image_Page()
        {
            //двойной клик по картинке
            img = new Image { Source = "flowers.jpg" };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = { img, sw } };
        }
        int tapid;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            //меняем картинку по двойному клику
            tapid++;
            var imgsender = (Image)sender;
            if (tapid % 2 == 0)
            {
                img.Source = "flowers.jpg";
            }
            else
            {
                img.Source = "funnily.jpg";
            }
        }

        //переключатель, показать или скрыть картинку (видимость изображения)
        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}