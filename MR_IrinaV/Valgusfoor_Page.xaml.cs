using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor_Page : ContentPage
    {
        private bool ButtonSisseClicked = false; //включение светофора
        private bool ButtonValjaClicked = false; //выключение светофора
        private bool isButtonFlashing = false; //мигание
        private bool isHorizontal = false; //повернуть светофор горизонтально

        public Valgusfoor_Page()
        {
            InitializeComponent();

            // Назначаем цвета кругам
            punaneFrame.BackgroundColor = Color.LightGray;
            kollaneFrame.BackgroundColor = Color.LightGray;
            rohelineFrame.BackgroundColor = Color.LightGray;

            // Добавляем обработчик нажатия на круги
            punaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Ошибка", "Сначала нажми на кнопку SISSE", "OK");
                        return;
                    }
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "STOP";
                    punaneLabel.FontAttributes = FontAttributes.Bold;
                    punaneLabel.FontSize = 17;
                    punaneLabel.TextColor = Color.Black;
                    DisplayAlert("Стой", "Красный", "OK");
                })
            });

            kollaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Ошибка", "Сначала нажми на кнопку SISSE", "OK");
                        return;
                    }
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "STOP\nWAIT"; //перенос слова на новую строку
                    kollaneLabel.FontAttributes = FontAttributes.Bold;
                    kollaneLabel.FontSize = 17;
                    kollaneLabel.TextColor = Color.Black;
                    DisplayAlert("Стой и Жди", "Желтый", "OK"); //всплывающее сообщение
                })
            });

            rohelineFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Ошибка", "Сначала нажми на кнопку SISSE", "OK");
                        return;
                    }
                    rohelineFrame.BackgroundColor = Color.Green;
                    rohelineLabel.Text = "GO";
                    rohelineLabel.FontAttributes = FontAttributes.Bold;
                    rohelineLabel.FontSize = 17;
                    rohelineLabel.TextColor = Color.Black;
                    DisplayAlert("Иди", "Зеленый", "OK");
                })
            });

            // Добавляем обработчик нажатия на кнопку "Sisse"
            ButtonSisse.Clicked += OnButtonSisseClicked;

            // Добавляем обработчик нажатия на кнопку "Flashing"
            //ButtonFlashing.Clicked += OnButtonFlashingClicked;

            // Добавляем обработчик нажатия на кнопку "Rotate"
            //ButtonRotate.Clicked += OnButtonRotateClicked;

            // Добавляем обработчик нажатия на кнопку "Välja"
            ButtonValja.Clicked += OnButtonValjaClicked;
        }

        private void OnButtonSisseClicked(object sender, EventArgs e)
        {
            ButtonSisseClicked = true;

            // изменяем фон кнопки на зеленый
            ButtonSisse.BackgroundColor = Color.LightGreen;

            // Изменяем цвета кругов на красный, желтый и зеленый
            punaneFrame.BackgroundColor = Color.Red;
            kollaneFrame.BackgroundColor = Color.Yellow;
            rohelineFrame.BackgroundColor = Color.Green;

            lbl3.IsVisible = true;
            lbl3.Text = "Нажми на круг и узнай действие";
            lbl3.FontSize = 18;
            lbl3.FormattedText = new FormattedString
            {
                // Создаем форматированную строку с разноцветным текстом
                Spans = {
                    new Span { Text = "Н", TextColor = Color.Red },
                    new Span { Text = "а", TextColor = Color.Orange },
                    new Span { Text = "ж", TextColor = Color.Green },
                    new Span { Text = "м", TextColor = Color.Red },
                    new Span { Text = "и ", TextColor = Color.Orange },
                    new Span { Text = "н", TextColor = Color.Green },
                    new Span { Text = "а ", TextColor = Color.Red },
                    new Span { Text = "к", TextColor = Color.Orange },
                    new Span { Text = "р", TextColor = Color.Green },
                    new Span { Text = "у", TextColor = Color.Red },
                    new Span { Text = "г ", TextColor = Color.Orange },
                    new Span { Text = "и ", TextColor = Color.Green },
                    new Span { Text = "у", TextColor = Color.Red },
                    new Span { Text = "з", TextColor = Color.Orange },
                    new Span { Text = "н", TextColor = Color.Green },
                    new Span { Text = "а", TextColor = Color.Red },
                    new Span { Text = "й ", TextColor = Color.Orange },
                    new Span { Text = "д", TextColor = Color.Green },
                    new Span { Text = "е", TextColor = Color.Red },
                    new Span { Text = "й", TextColor = Color.Orange },
                    new Span { Text = "с", TextColor = Color.Green },
                    new Span { Text = "т", TextColor = Color.Red },
                    new Span { Text = "в", TextColor = Color.Orange },
                    new Span { Text = "и", TextColor = Color.Green },
                    new Span { Text = "е", TextColor = Color.Red }
                }
            };
        }
        private async void OnButtonFlashingClicked(object sender, EventArgs e)
        {
            isButtonFlashing = !isButtonFlashing;

            if (isButtonFlashing) // запускаем бесконечный цикл при первом нажатии кнопки
            {
                while (isButtonFlashing)
                {
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "STOP";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    punaneFrame.BackgroundColor = Color.LightGray;
                    punaneLabel.Text = "punane";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "STOP\nWAIT";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    kollaneFrame.BackgroundColor = Color.LightGray;
                    kollaneLabel.Text = "kollane";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    rohelineFrame.BackgroundColor = Color.Green;
                    rohelineLabel.Text = "GO";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    rohelineFrame.BackgroundColor = Color.LightGray;
                    rohelineLabel.Text = "roheline";
                    await Task.Delay(800);
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "STOP\nWAIT";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    kollaneFrame.BackgroundColor = Color.LightGray;
                    kollaneLabel.Text = "kollane";
                    await Task.Delay(800);
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "STOP";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "STOP";
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "STOP\nWAIT";
                    rohelineFrame.BackgroundColor = Color.Green;
                    rohelineLabel.Text = "GO";
                    await Task.Delay(800);
                    if (!isButtonFlashing) break;
                    punaneFrame.BackgroundColor = Color.LightGray;
                    punaneLabel.Text = "punane";
                    await Task.Delay(500);
                    if (!isButtonFlashing) break;
                    kollaneFrame.BackgroundColor = Color.LightGray;
                    kollaneLabel.Text = "kollane";
                    await Task.Delay(500);
                    if (!isButtonFlashing) break;
                    rohelineFrame.BackgroundColor = Color.LightGray;
                    rohelineLabel.Text = "roheline";
                    await Task.Delay(500);
                    if (!isButtonFlashing) break;
                    // если нажать на кнопку второй раз, то остановка
                }
            }

            // остановка мигания и возврат к первоначальным цветам и тексту на кругах
            else
            {
                punaneFrame.BackgroundColor = Color.LightGray;
                punaneLabel.Text = "punane";
                kollaneFrame.BackgroundColor = Color.LightGray;
                kollaneLabel.Text = "kollane";
                rohelineFrame.BackgroundColor = Color.LightGray;
                rohelineLabel.Text = "roheline";

                isButtonFlashing = false;
            }
        }
        //повернуть светофор горизонтально,
        //все запущенные другие кнопки будут работать также,
        //как и при вертикальном положении
        private async void OnButtonRotateClicked(object sender, EventArgs e)
        {
            isHorizontal = !isHorizontal;

            if (isHorizontal) //поворот на 90 градусов
            {
                await Task.WhenAll(
                Container.RotateTo(-90, 500),
                punaneFrame.RotateTo(90, 500),
                kollaneFrame.RotateTo(90, 500),
                rohelineFrame.RotateTo(90, 500)
                );
            }
            else //второе нажатие на кнопку возвращает в вертикальное положение
            {
                await Task.WhenAll(
                Container.RotateTo(0, 500),
                punaneFrame.RotateTo(0, 500),
                kollaneFrame.RotateTo(0, 500),
                rohelineFrame.RotateTo(0, 500)
                );
            }
        }
        private void OnButtonValjaClicked(object sender, EventArgs e)
        {
            ButtonValjaClicked = true;

            //ButtonValja.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //Command = new Command(async () =>

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Выключение светофора",
                                    "Вы уверены, что хотите выключить светофор?",
                                    "Да", "Нет");

                if (answer == true)
                {
                    //isFlashing = false;
                    ButtonSisseClicked = false;

                    // Возвращаем фон кнопки sisse к значению по умолчанию
                    ButtonSisse.BackgroundColor = Color.Default;

                    // Возвращаем цвета кругов обратно на серый
                    punaneFrame.BackgroundColor = Color.LightGray;
                    kollaneFrame.BackgroundColor = Color.LightGray;
                    rohelineFrame.BackgroundColor = Color.LightGray;

                    //Возвращаем надписи в круги
                    punaneLabel.Text = "punane";
                    punaneLabel.FontSize = 17;
                    kollaneLabel.Text = "kollane";
                    kollaneLabel.FontSize = 17;
                    rohelineLabel.Text = "roheline";
                    rohelineLabel.FontSize = 17;

                    // Обновляем текст надписи
                    lbl3.Text = "Нажми SISSE и включи светофор";
                }
                else
                {
                    //Светофор не выключаем
                    ButtonValjaClicked = false;
                    ButtonSisseClicked = true;

                }

            });
            //});
        }
    }
}