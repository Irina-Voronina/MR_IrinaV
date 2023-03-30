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
        //ScrollView scrollView;

        // создаем GradientStop с указанием цвета и смещения
        GradientStop green = new GradientStop { Color = Color.Green, Offset = 0 }; //для кнопки светофора
        GradientStop yellow = new GradientStop { Color = Color.Yellow, Offset = 0.3f };
        GradientStop yellow2 = new GradientStop { Color = Color.Yellow, Offset = 0.7f };
        GradientStop red = new GradientStop { Color = Color.Red, Offset = 1 };

        GradientStop dodgerblue = new GradientStop { Color = Color.DodgerBlue, Offset = 0 }; //для кнопки снеговика
        GradientStop white = new GradientStop { Color = Color.White, Offset = 0.4f };
        GradientStop white2 = new GradientStop { Color = Color.White, Offset = 0.6f };
        GradientStop dodgerblue2 = new GradientStop { Color = Color.DodgerBlue, Offset = 1 };

        // создаем коллекцию GradientStopCollection и добавляем в нее GradientStop
        GradientStopCollection gradientStops = new GradientStopCollection { };
        GradientStopCollection gradientStops2 = new GradientStopCollection { };

        Button Valgusfoor_btn;
        Button Lumememm_btn;

        // создаем список ContentPage и инициализируем его объектами ContentPage
        List<ContentPage> pages = new List<ContentPage>() { new Entry_Page(), new Timer_Page(), new BoxView_Page(), new Valgusfoor_Page(), new DateTime_Page(), new StepperSlider_Page(), new Lumememm_Page(), new Frame_Page(), new Image_Page(), new Image_Page_2(), new PopUp_Page(), new Anketa_Page(), new Guess_Page() }; // index= 0,1,2,...

        // создаем список строк и инициализируем его строками
        List<string> tekstid = new List<string> { "Ava Entry leht", "Ava Timer leht", "Ava Box leht", "Valgusfoor", "Ava DateTime leht", "Ava StepperSlider leht", "Lumememm", "Ava Frame leht", "Ava Image leht", "Image***", "Ava Pop_Up leht", "Anketa", "Guess" };
        
        // создаем список цветов и инициализируем его объектами Color или LinearGradientBrush
        List<Color> backgroundColors = new List<Color>() { Color.SpringGreen, Color.SpringGreen, Color.SpringGreen, Color.Default, Color.SpringGreen, Color.SpringGreen, Color.Default, Color.SpringGreen, Color.SpringGreen, Color.DodgerBlue, Color.SpringGreen, Color.DodgerBlue, Color.DodgerBlue };

        // создаем список цветов текста и инициализируем его объектами Color
        List<Color> textColors = new List<Color>() { Color.DarkOrange, Color.DarkOrange, Color.DarkOrange, Color.Green, Color.DarkOrange, Color.DarkOrange, Color.DodgerBlue, Color.DarkOrange, Color.DarkOrange, Color.White, Color.DarkOrange, Color.White, Color.White };


        public StartPage()
        {
            //InitializeComponent();

            //scrollView = new ScrollView();

            // добавляем GradientStop в коллекцию GradientStopCollection
            gradientStops.Add(green); //для кнопки светофор
            gradientStops.Add(yellow);
            gradientStops.Add(yellow2);
            gradientStops.Add(red);

            gradientStops2.Add(dodgerblue); //для кнопки снеговик
            gradientStops2.Add(white);
            gradientStops2.Add(white2);
            gradientStops2.Add(dodgerblue2);


            Valgusfoor_btn = new Button
            {
                Background = new LinearGradientBrush
                {
                    GradientStops = gradientStops,
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0)
                }
            };

            Lumememm_btn = new Button
            {
                Background = new LinearGradientBrush
                {
                    GradientStops = gradientStops2,
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0)
                }
            };

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
                    //BackgroundColor = Color.SpringGreen,
                    //TextColor = Color.DarkOrange
                    BackgroundColor = backgroundColors[i],
                    TextColor = textColors[i],
                    HeightRequest = 35 // задаем высоту кнопки
                };

                if (i == 3) // Индекс 3 - это четвертая кнопка, которая должна иметь градиентный фон
                {
                    button.Background = new LinearGradientBrush
                    {
                        GradientStops = gradientStops,
                        StartPoint = new Point(0, 0),
                        EndPoint = new Point(1, 0)
                    };
                }

                if (i == 6) // Индекс 7 - это шестая кнопка, которая должна иметь градиентный фон
                {
                    button.Background = new LinearGradientBrush
                    {
                        GradientStops = gradientStops2,
                        StartPoint = new Point(0, 0),
                        EndPoint = new Point(1, 0)
                    };
                }

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

     

    
