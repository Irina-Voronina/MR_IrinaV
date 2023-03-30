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
    public partial class Anketa_Page : ContentPage
    {
        private int questionIndex = 0;
        private List<Question> questions = new List<Question>
    {
        new Question
        {
            Text = "Какое ваше любимое животное?",
            Answers = new List<string> { "Кошка", "Собака", "Хомяк" }
        },
        new Question
        {
            Text = "Какую кухню вы предпочитаете?",
            Answers = new List<string> { "Итальянскую", "Французскую", "Японскую" }
        },

        new Question
            {
                Text = "Какое ваше любимое блюдо и как его готовить?",
                Answers = new List<string>
                {
                    "Пицца - Надо замесить тесто, выложить на него соус, сыр, колбасу, грибы, оливки и другие ингредиенты по вкусу, и запекать в духовке.",
                    "Борщ - Надо нарезать мясо и овощи, сварить на бульоне, добавить свеклу и томатную пасту, заправить сметаной.",
                    "Салат Цезарь - Надо нарезать салат Ромэн, приготовить куриную грудку, гренки, тертый пармезан, и заправить соусом из сливок, чеснока, горчицы, лимона и оливкового масла."
                }
            }


        };

        public Anketa_Page()
        {
            InitializeComponent();

            ShowQuestion();
        }

        private void ShowQuestion()
        {
            Question currentQuestion = questions[questionIndex];

            Label questionLabel = new Label
            {
                Text = currentQuestion.Text,
                FontSize = 24,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 50, 0, 0)
            };

            List<Button> answerButtons = new List<Button>();
            foreach (string answer in currentQuestion.Answers)
            {
                Button answerButton = new Button
                {
                    Text = answer,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 20, 0, 0)
                };
                answerButton.Clicked += AnswerButton_Clicked;
                answerButtons.Add(answerButton);
            }

            StackLayout layout = new StackLayout
            {
                Children = { questionLabel }
            };
            foreach (Button answerButton in answerButtons)
            {
                layout.Children.Add(answerButton);
            }
            Content = layout;
        }

        private async void GoToGuessPage()
        {
            await Navigation.PushAsync(new Guess_Page());
        }
        private async void AnswerButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string answer = button.Text;
            await DisplayAlert("Выбранный ответ", answer, "OK");

            questionIndex++;
            if (questionIndex < questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                await DisplayAlert("Конец вопросов", "Спасибо за участие! А теперь загадки!!!", "OK");
                GoToGuessPage();
            }
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
    }

    
}