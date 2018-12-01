using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waterAppDev2018.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace waterAppDev2018
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
        public int pickedWeight;
        public int wakeUptime;
        public int bedTime;
        public string measureSys;

        public Settings ()
		{
			InitializeComponent ();
            WeightPickerOptions();
            MeasurementSystem();

        }

        private void MeasurementSystem()
        {
            MeasurementPicker.ItemsSource = new string[] { "Metric (kgs/mls)","Imperial (lbs/oz)" };

        }

        private void MeasurementPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int whichMeasureSys = (int)(MeasurementPicker.SelectedIndex);
            switch (whichMeasureSys)
            {
                case 1:
                    measureSys = "Metric";
                    break;
                case 2:
                    measureSys = "Imperial";
                    break;
                default:
                    measureSys = "Metric";
                    break;
            }

        }

        private void WakeTime_BindingContextChanged(object sender, EventArgs e)
        {
            string time = (wakeTime.ToString());
            wakeUptime = Convert.ToInt32(time);
        }

        private void SleepTime_BindingContextChanged(object sender, EventArgs e)
        {
            string time = (SleepTime.ToString());
            bedTime = Convert.ToInt32(time);
        }

        private void WeightPickerOptions()
        {
            WeightPicker.ItemsSource = new int[]
            {1,2,3,4,5,6,7,8,9,10,
                11,12,13,14,15,16,17,18,19,20,
                21,22,23,24,25,26,27,28,29,30,
                31,32,33,34,35,36,37,38,39,
                40,41,42,43,44,45,46,47,48,49,50,
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
            pickedWeight = (int)(WeightPicker.SelectedIndex);
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            DbClass dbClass = new DbClass()
            {
                DbWeight = pickedWeight,
                DbMeasureSys = measureSys,
                DbWakeUp = wakeUptime,
                DbBedTime = bedTime
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<DbClass>();
                int rows = conn.Insert(dbClass);


                if (rows > 0)
                DisplayAlert("Success", "Succesfully saved inputs", "Ok");
                else
                DisplayAlert("Failed", "Failed to save inputs", "Ok");
            }

            Navigation.PushAsync(new MainPage());

        }
    }
}