using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace waterAppDev2018
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Modifications : ContentPage
	{
        public string hotToday, sportsToday;

        public Modifications ()
		{
			InitializeComponent ();
            showPickerOptions();
		}

        private void sports_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sport = (int)(sports.SelectedIndex);
            
            switch (sport)
            {
                case 0:
                    this.sportsToday = "Yes";
                    break;
                case 1:
                    this.sportsToday = "Yes";
                    break;
            }
        }

        private void showPickerOptions()
        {
            sports.ItemsSource = new string[] { "Yes", "No" };
            hotWeather.ItemsSource = new string[] { "Yes", "No" };
        }

        private void hotWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hotWeather = (int)(sports.SelectedIndex);
            
            switch (hotWeather)
            {
                case 0:
                    this.hotToday = "Yes";
                    break;
                case 1:
                    this.hotToday = "No";
                    break;
            }


        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            
        }

        
    }
}