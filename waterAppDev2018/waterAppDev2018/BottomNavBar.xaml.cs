using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace waterAppDev2018
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BottomNavBar : ContentPage
	{
		public BottomNavBar ()
		{
			InitializeComponent ();
            showIcons();
            defaultTabStart();
        }

        private void defaultTabStart()
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        private void showIcons()
        {
            var assembly = typeof(MainPage);
            HomeIcon.Source = ImageSource.FromResource(
                "waterAppDev2018.Assets.Images.icons8-home-page-24.png", assembly);
            ModificationsIcon.Source = ImageSource.FromResource(
                "waterAppDev2018.Assets.Images.icons8-compose-24.png", assembly);
            SettingsIcon.Source = ImageSource.FromResource(
                "waterAppDev2018.Assets.Images.icons8-settings-24.png", assembly);
        }

        private void Home_Tapped(object sender, EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;

        }



        private void Modifications_Tapped(object sender, EventArgs e)
        {
            var page = new Modifications();
            PlaceHolder.Content = page.Content;

        }

        private void Settings_Tapped(object sender, EventArgs e)
        {
            var page = new Settings();
            PlaceHolder.Content = page.Content;

        }

    }
}