using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lumememm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LumememmPage : ContentPage
    {
        private bool HideButtonClicked = true;
        private bool JumpButtonClicked = true;

        public LumememmPage()
        {
            InitializeComponent();

            HideButton.Clicked += OnHideButtonClicked;
            ShowButton.Clicked += OnShowButtonClicked;
            ColorButton.Clicked += OnColorButtonClicked;
            MeltButton.Clicked += OnMeltButtonClicked;
            TagasiButton.Clicked += OnTagasiButtonClicked;
            JumpButton.Clicked += OnJumpButtonClicked;
        }

        
        private void OnHideButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = false;
        }

        
        private async void OnShowButtonClicked(object sender, EventArgs e)
        {
            Container.IsVisible = true;

            Pea.BackgroundColor = Color.White;
            Kael.BackgroundColor = Color.White;
            Keha.BackgroundColor = Color.White;

            await Container.FadeTo(1, 1000, Easing.CubicIn);
            await Container.TranslateTo(0, 0, 2000, Easing.CubicOut);

            await Pea.ScaleTo(1, 1000, Easing.CubicIn);
            await Kael.ScaleTo(1, 1000, Easing.CubicIn);
            await Keha.ScaleTo(1, 1000, Easing.CubicIn);

            await Task.WhenAll(
            Pea.TranslateTo(0, 0, 1000),
            Kael.TranslateTo(0, 0, 1000),
            Keha.TranslateTo(0, 0, 1000));
        }

        
        private void OnColorButtonClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Color PeaColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color KaelColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
            Color KehaColor = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            Pea.BackgroundColor = PeaColor;
            Kael.BackgroundColor = KaelColor;
            Keha.BackgroundColor = KehaColor;
        }

        
        private async void OnMeltButtonClicked(object sender, EventArgs e)
        {
            double targetY = Height + Container.Height;

            await Container.TranslateTo(0, targetY, 2000, Easing.CubicIn);
            await Container.FadeTo(0, 3000, Easing.CubicOut);

            Container.IsVisible = false;

            await Pea.ScaleTo(0, 1000);
            await Kael.ScaleTo(0, 1000, Easing.CubicOut);
            await Keha.ScaleTo(0, 1000, Easing.CubicOut);

            await Task.WhenAll(
            Pea.TranslateTo(0, 200, 2000),
            Kael.TranslateTo(0, 200, 2000),
            Keha.TranslateTo(0, 200, 2000));
        }

        
        private async void OnTagasiButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}