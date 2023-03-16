using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = Xamarin.Forms.Color;

namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lumememm_Page : ContentPage
    {
        private bool HideButtonClicked = true;
        private bool FlipButtonClicked = true;
        //private EventHandler OnFlipButtonClicked;

        public Lumememm_Page()
        {
            InitializeComponent();

            // добавляем обработчики событий кнопок
            HideButton.Clicked += OnHideButtonClicked;
            ShowButton.Clicked += OnShowButtonClicked;
            ColorButton.Clicked += OnColorButtonClicked;
            MeltButton.Clicked += OnMeltButtonClicked;
            DanceButton.Clicked += OnDanceButtonClicked;
            FlipButton.Clicked += OnFlipButtonClicked;
            
        }

        //private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
            //pea.Padding = stp.Value;
            //telo.Padding = stp.Value;
            //vedro.Padding = stp.Value;
            //bubon.Padding = stp.Value;
        //}

        // Обработчик события для кнопки "Спрятать"
        private void OnHideButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = false;
        }

        // Обработчик события для кнопки "Отобразить"
        private async void OnShowButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = true;

            // Возвращаем исходные цвета для всех элементов, понадобится, когда будем раскрашивать рандомно
            pea.BackgroundColor = Color.White;
            telo.BackgroundColor = Color.White;
            vedro.BackgroundColor = Color.Black;
            bubon.BackgroundColor = Color.Black;
            nos.Color = Color.Orange;
            p1.Color = Color.Black;
            p2.Color = Color.Black;
            p3.Color = Color.Black;

            // Возвращаем контейнер на место, понадобится, когда снеговик растает
            await Container.FadeTo(1, 1000, Easing.CubicIn);
            await Container.TranslateTo(0, 0, 2000, Easing.CubicOut);

            // Возвращаем фреймы на место
            await vedro.ScaleTo(1, 1000, Easing.CubicIn);
            await bubon.ScaleTo(1, 1000, Easing.CubicIn);
            await pea.ScaleTo(1, 1000, Easing.CubicIn);
            await telo.ScaleTo(1, 1000, Easing.CubicIn);

            //вернуть снеговика на место после сдвига вниз за пределы страницы
            await Task.WhenAll(
            telo.TranslateTo(0, 0, 1000),
            pea.TranslateTo(0, 0, 1000),
            vedro.TranslateTo(0, 0, 1000),
            bubon.TranslateTo(0, 0, 1000)
            //Container.TranslateTo(0, 0, 1000)
            );
        }

        // Обработчик события для кнопки "Раскрасить"
        private void OnColorButtonClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Генерация случайных цветов для каждого фрейма и носа
            Color peaColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color teloColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color bubonColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color vedroColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color nosColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color p1Color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color p2Color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color p3Color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            // Установка случайных цветов для головы, бубона, тела, пуговиц
            pea.BackgroundColor = peaColor;
            telo.BackgroundColor = teloColor;
            bubon.BackgroundColor = bubonColor;
            vedro.BackgroundColor = vedroColor;
            nos.Color = nosColor;
            p1.Color = p1Color;
            p2.Color = p2Color;
            p3.Color = p3Color;
        }

        // Обработчик события для кнопки "Растопить"
        private async void OnMeltButtonClicked(object sender, EventArgs e)
        {
            // Изменяем высоту Grid
            //await Container.TranslateTo(0, Height - Container.Height, 2000, Easing.CubicIn);

            // вычислить позицию ниже границ страницы
            double targetY = Height + Container.Height;

            // переместить снеговика ниже границы страницы
            await Container.TranslateTo(0, targetY, 2000, Easing.CubicIn);
            await Container.FadeTo(0, 3000, Easing.CubicOut);

            Container.IsVisible = false;

            // Изменяем размер фреймов, чтобы снеговик растаял
            await vedro.ScaleTo(0, 1000);
            await bubon.ScaleTo(0, 1000);
            await pea.ScaleTo(0, 1000);
            await telo.ScaleTo(0, 1000, Easing.CubicOut);

            // Анимация, которая сдвигает фреймы вниз
            await Task.WhenAll(
            telo.TranslateTo(0, 200, 2000),
            pea.TranslateTo(0, 200, 2000),
            vedro.TranslateTo(0, 200, 2000),
            bubon.TranslateTo(0, 200, 2000)
            );

            // Изменяем размер фреймов, чтобы снеговик растаял
            //vedro.WidthRequest = 0;
            //vedro.HeightRequest = 0;
            //pea.WidthRequest = 0;
            //pea.HeightRequest = 0;
            //telo.WidthRequest = 0;
            //telo.HeightRequest = 0;
            //bubon.WidthRequest = 0;
            //bubon.HeightRequest = 0;
        }

        // Обработчик события для кнопки "Танец"
        private async void OnDanceButtonClicked(object sender, EventArgs e)
        {
            await Container.TranslateTo(0, -20, 200); // подпрыгивание
            await Container.TranslateTo(0, 20, 200);
            await Container.TranslateTo(0, -10, 200);
            await Container.TranslateTo(0, 10, 200);

            await Container.RotateTo(45, 500); // поворачиваем контейнер на 45 градусов вправо
            await Container.RotateTo(-45, 500); // поворачиваем контейнер на 45 градусов влево
            await Container.RotateTo(0, 500); // возвращаем контейнер в исходное положение
            await Container.RotateTo(45, 500);
            await Container.RotateTo(-45, 500);
            await Container.RotateTo(0, 500);

            await Container.TranslateTo(0, -20, 200); // подпрыгивание
            await Container.TranslateTo(0, 20, 200);
            await Container.TranslateTo(0, -10, 200);
            await Container.TranslateTo(0, 10, 200);

            //двигаем глаза
            await prav.TranslateTo(30, 10, 100);
            await lev.TranslateTo(30, 10, 100);
            await prav.TranslateTo(-30, -10, 100);
            await lev.TranslateTo(-30, -10, 100);
            await prav.TranslateTo(0, 0, 100);
            await lev.TranslateTo(0, 0, 100);

            await Container.TranslateTo(-20, 0, 200); // двигаем контейнер влево
            await Container.TranslateTo(30, 0, 200); // двигаем контейнер вправо
            await Container.TranslateTo(-20, 0, 200); // двигаем контейнер влево
            await Container.TranslateTo(0, 0, 200); // возвращаем контейнер на исходную позицию
            await Container.TranslateTo(-20, 0, 200);
            await Container.TranslateTo(30, 0, 200);
            await Container.TranslateTo(-20, 0, 200);
            await Container.TranslateTo(0, 0, 200);

            await Container.TranslateTo(0, -20, 200); // подпрыгивание
            await Container.TranslateTo(0, 20, 200);
            await Container.TranslateTo(0, -10, 200);
            await Container.TranslateTo(0, 10, 200);


            //await nos.TranslateTo(50, nos.TranslationY, 500, Easing.SinInOut); //двигаем нос вправо
            //await nos.TranslateTo(-50, nos.TranslationY, 1000, Easing.SinInOut); //двигаем нос влево
            //await nos.TranslateTo(50, nos.TranslationY, 1000, Easing.SinInOut); //снова направо
            //await nos.TranslateTo(20, nos.TranslationY, 500, Easing.SinInOut); //возвращем в центр

            await nos.RotateTo(90, 500, Easing.SinInOut); //поварачиваем нос
            await nos.RotateTo(-180, 500, Easing.SinInOut);
            await nos.RotateTo(0, 500, Easing.SinInOut);

            //двигаем глаза
            await prav.TranslateTo(30, 10, 100);
            await lev.TranslateTo(30, 10, 100);
            await prav.TranslateTo(-30, -10, 100);
            await lev.TranslateTo(-30, -10, 100);
            await prav.TranslateTo(0, 0, 100);
            await lev.TranslateTo(0, 0, 100);

        }


        // Обработчик события для кнопки "Сальто"
        private async void OnFlipButtonClicked(object sender, EventArgs e)
        {

            await Container.RotateTo(720, 1500);
            await Container.RotateTo(-360, 1500);

            // Создаем анимацию
            //var animation = new Animation();

            // Переворачиваем снеговика вниз
            //animation.Add(0.0, 0.5, new Animation(v => Container.RotationX = v, 0, 180));

            // Переворачиваем снеговика обратно
            //animation.Add(0.5, 1.0, new Animation(v => Container.RotationX = v, 180, 0));

            // Запускаем анимацию
            //await animation.Commit(Container, "SaltoAnimation", length: 1000);

        }


    }
}