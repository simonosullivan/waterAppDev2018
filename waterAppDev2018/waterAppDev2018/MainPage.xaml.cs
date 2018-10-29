using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace waterAppDev2018
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //SetupImages();
        }

        private void AddQuantityButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddWaterQuantity());
        }

        private void SetupImages()
        {
            var assembly = typeof(MainPage);
            WaterGlass.Source = ImageSource.FromResource("waterAppDev2018.Assets.Images.WaterGlass.jpg", assembly);
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}
