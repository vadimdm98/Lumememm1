using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lumememm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new LumememmPage() };
        List<string> tekstid = new List<string> { "Open Lumememm" };
        public MainPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Blue
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.Fuchsia,
                    TextColor = Color.Black
                };
                st.Children.Add(button);
                button.Clicked += Navig_funktsion;
            }
            Content = st;
        }

        private async void Navig_funktsion(object sender, EventArgs e)
        {
            Button btn = sender as Button; 
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}