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
	public partial class Weight : ContentPage
	{
		public Weight ()
		{
			InitializeComponent ();
            WeightPickerOptions();     

        }

        private void WeightPickerOptions()
        {
            WeightPicker.ItemsSource = new int[]
            {40,41,42,43,44,45,46,47,48,49,50,
                51,52,53,54,55,56,57,58,59,60,
                61,62,63,64,65,66,67,68,69,70,
                71,72,73,74,75,76,77,78,79,80,
                81,82,83,84,85,86,87,88,89,90,
                91,92,93,94,95,96,97,98,99,100,
                101,102,103,104,105,106,107,108,109,110,
                111,112,113,114,115,116,117,118,119,120};
        }

        private void WeightPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasurementSystem weight = new MeasurementSystem();
            weight.Weight(WeightPicker.SelectedIndex);
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}