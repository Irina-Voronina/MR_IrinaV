using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MR_IrinaV.Guess_Page;


namespace MR_IrinaV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Guess_Page : ContentPage
    {
        public FlowDirection AlertArguments { get; set; }

        public Guess_Page()
        {
            InitializeComponent();

            Button alertListButton = new Button
            {
                Text = "ЗАГАДКИ",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.DodgerBlue,
                TextColor = Color.White,
                BorderColor = Color.SpringGreen,
                //CornerRadius = 30,
                BorderWidth = 10,
                HeightRequest = 100,
                WidthRequest = 700
            };

            alertListButton.Clicked += AlertListButton_Clicked;

            Content = new StackLayout { Children = {alertListButton } };

        }

        private async void GoToMolodetsPage()
        {
            await Navigation.PushAsync(new Molodets_Page());
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            // Список вопросов и ответов
            string[] questions = { "Кто твой классный руководитель?", "Какого числа сдавать экзаменационный ИТ-проект?", "Какого числа твоя защита прохождения практики?", "Какой сегодня месяц и год?", "Ты же справишься с экзаменом?" };
            string[][] answers = {
            new string[] { "Марина О.", "Михаил А.", "Ирина М." },
            new string[] { "12 мая 2023 г.", "13 июня 2023 г.", "25 мая 2023 г." },
            new string[] { "13 июня 2023 г.", "20 июня 2023 г.", "25 мая 2023 г." },
            new string[] { "Январь 2023 г.", "Март 2023 г.", "Февраль 2023 г." },
            new string[] { "Да", "Да", "Да" }

        };
            // Массив для хранения выбранных ответов
            string[] selectedAnswers = new string[questions.Length];

            // Массив для хранения правильных ответов
            string[] correctAnswers = { "Ирина М.", "12 мая 2023 г.", "13 июня 2023 г.", "Март 2023 г.", "Да" };

            int score = 0; // Счетчик правильных ответов

            for (int i = 0; i < questions.Length; i++)
            {
                string question = questions[i];
                string[] options = answers[i];

                // Отображаем вопрос и варианты ответов
                var action = await DisplayActionSheet(question, "Отмена", null, options);

                // Отображаем выбранный ответ
                if (action != null && action != "Отмена")
                {
                    await DisplayAlert("Выбранный ответ", action, "OK");
                    selectedAnswers[i] = action;

                    // Проверяем ответ на правильность
                    if (action == correctAnswers[i])
                    {
                        score++;
                    }
                }
            }

            // Выводим результаты
            string result = "Результаты опроса:\n\n";
            for (int i = 0; i < questions.Length; i++)
            {

                result += $"{i + 1}. {questions[i]} \nТвой ответ: {selectedAnswers[i] ?? "- Не выбран ответ"}";
                if (selectedAnswers[i] == null)
                {
                    result += "\n - Не ответил(а)";
                }
                else if (selectedAnswers[i] == correctAnswers[i])
                {
                    result += "\n + Правильно!";
                }
                else
                {
                    result += "\n - Неправильно";
                }
                result += "\n";
            }

            
            await DisplayAlert("Результаты\n", result, "OK");
            await DisplayAlert("Результаты\n", $"Вы ответили правильно на {score} из {questions.Length} вопросов \nНо это не так важно ;)\nА важно следующее сообщение!", "OK");

            await DisplayAlert("ЗАПОМИНАЙ!", "У тебя остался ещё месяц, чтобы дописать ИТ-проект для защиты!\nТы обязательно допишешь ;)\nГлавное нАчать!!!", "OK");

            GoToMolodetsPage();

        }


    }
}