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
        int totalDrank = 0;
        int amountTarget;

        public MainPage()
        {
            InitializeComponent();
            //SetupImages();
            WeightPickerOptions();
            
        }

        private void AddQuantityButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddWaterQuantity());
        }

        private void DrinkMeter()
        {
            MeasurementSystem target = new MeasurementSystem();
            amountTarget = target.DrinkAmount();
            targetWaterIntake.Text = "Target : " + amountTarget + " mls";

            //int guideDrank = target.TargetLine();
            //guide.Text = "Guide amount drunk : " + guideDrank + " mls";

            AddWaterQuantity water = new AddWaterQuantity();
            int drank = water.AddWater();
            drinkMeter.Text = "Drunk : " + drank + " mls";

        }

        //private void SetupImages()
        //{
        //    var assembly = typeof(MainPage);
        //    WaterGlass.Source = ImageSource.FromResource("waterAppDev2018.Assets.Images.WaterGlass.jpg", assembly);
        //}

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Weight());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Modifications());
        }

        private void addMlsButton_Clicked(object sender, EventArgs e)
        {
            int drunk = AddWater();
            totalDrank += drunk;
            drinkMeter.Text = "Drunk : " + totalDrank + "  mls";
        }

        public int AddWater()
        {
            int drunk;//= int.Parse(mlsEntry.Text);
            drunk = Convert.ToInt32(mlsEntry.Text);
            return drunk;
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
            MeasurementSystem weight = new MeasurementSystem();
            weight.Weight(WeightPicker.SelectedIndex);
            DrinkMeter();
            
        //    int weight = WeightPicker.SelectedIndex;
            
        //    if (weight >= 90)
        //    {
        //        amountTarget = 2800;
        //    }
        //    else if (weight >= 65)
        //    {
        //        amountTarget = 2400;
        //    }
        //    else
        //    {
        //        amountTarget = 2100;
        //    }
            
            
        //    DrinkMeter();
        }

        //private void SubmitButton_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
