using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.Shapes;

using Rectangle = Xamarin.Forms.Rectangle;


namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Image_Page_2 : ContentPage
    {
        Switch sw;
        Image img;

        //создаём списко изображений
        List<string> imagePaths = new List<string> { "flowers.jpg", "funnily.jpg", "neuro.jpg", "swirl.jpg", "uvula.png" };
        int currentImageIndex = 0;

        public Image_Page_2()
        {
            //двойной клик по картинке
            img = new Image { Source = imagePaths[currentImageIndex], Aspect = Aspect.AspectFill }; //делаем картинку во весь экран
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            sw = new Switch
            {
                //переключатель скрыть изображение
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                OnColor = Color.White, // изменяем цвет переключателя
                ThumbColor = Color.Red, //цвет бегунка на переключателе
                WidthRequest = 100,
                HeightRequest = 50
            };

            // добавить для видимости переключателя фон
            //sw.WidthRequest = 50;
            //sw.HeightRequest = 20;
            //sw.BackgroundColor = Color.White;

            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = { img, sw } };

            //создаем AbsoluteLayout и добавляем в него изображение
            //делаем картинку во весь экран
            var layout = new AbsoluteLayout();
            AbsoluteLayout.SetLayoutFlags(img, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(img, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(img);

             //добавляем переключатель внизу экрана
            AbsoluteLayout.SetLayoutFlags(sw, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(sw, new Rectangle(0.5, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            layout.Children.Add(sw);

            this.Content = layout;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            //меняем картинку по двойному клику
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
            img.Source = imagePaths[currentImageIndex];
        }

        //переключатель, показать или скрыть картинку (видимость изображения)
        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            img.IsVisible = e.Value;
        }
    }
}