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
    public partial class Entry_Page : ContentPage
    {
        
            Editor ed;
            Button btn;
            Label lbl;
            public Entry_Page()
            {
                ed = new Editor
                {
                    Placeholder = "Sisesta siia tekst",
                    BackgroundColor = Color.White,
                    TextColor = Color.Plum
                };
                ed.TextChanged += Ed_TextChanged;
                lbl = new Label
                {
                    Text = "Mingi tekst",
                    TextColor = Color.White,
                    BackgroundColor = Color.Violet
                };
                btn = new Button
                {
                    Text = "Tagasi"
                };
                StackLayout st = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { ed, lbl, btn },
                    BackgroundColor = Color.Pink
                };
                Content = st;
                btn.Clicked += Btn_Clicked;
            }
            int i = 0;
            private void Ed_TextChanged(object sender, TextChangedEventArgs e)
            {
                ed.TextChanged -= Ed_TextChanged;
                char key = e.NewTextValue?.LastOrDefault() ?? ' ';

                //lbl.Text = ed.Text;
                //throw new NotImplementedException();

                if (key == 'A')
                {
                    i++;
                    lbl.Text = key.ToString() + ": " + i;
                }

                ed.TextChanged += Ed_TextChanged;
            }

            //private void Ed_TextChanged1(object sender, TextChangedEventArgs e)
            // {
            //throw new NotImplementedException();
            //}

            private async void Btn_Clicked(object sender, EventArgs e)
            {
                await Navigation.PopAsync();
            }
        
    }
}