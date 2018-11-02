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
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
            MeasurementSystem();

        }

        private void MeasurementSystem()
        {
            MeasurementPicker.ItemsSource = new string[] { "Metric (kgs/mls)","Imperial (lbs/oz)" };

        }

        private void MeasurementPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasurementSystem change = new MeasurementSystem();
            change.MeasureSystem(MeasurementPicker.SelectedIndex);
        }

        
    }
}