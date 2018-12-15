using BottomBar.XamarinForms;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using waterAppDev2018.Model;
using Xamarin.Forms;

namespace waterAppDev2018
{
    public partial class MainPage : ContentPage
    {
        int totalDrank = 0;
        public int amountTarget;
        private const string JSON_FILENAME = "Drink-Up_JsonLocal.txt";
        public List<JsonToObject> jsonToObjects;
        //bool firstLaunch = false;


        public MainPage()
        {
            InitializeComponent();
            
            ReadFromJson();
            //SetupImages();
            //DrinkMeter();


        }

        private void ReadFromJson()
        {
            try
            {
                // Read the list from a local file
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, JSON_FILENAME);

                // use a stream reader to read the text out to file
                using (var streamReader = new StreamReader(filename, false))
                {
                    string jsonText = streamReader.ReadToEnd();
                    jsonToObjects = JsonConvert.DeserializeObject<List<JsonToObject>>(jsonText);
                }
                JsonToObject objs = new JsonToObject();
                foreach (var obj in jsonToObjects)
                {

                    objs.Weight = obj.Weight;
                    amountTarget = objs.DrinkAmount(objs.Weight);
                    targetWaterIntake.Text = "Target : " + amountTarget + " mls";
                    objs.WakeUpTime = obj.WakeUpTime;
                    objs.SleepTime = obj.SleepTime;
                    double guidePerHour = objs.TargetLine(amountTarget);
                    guide.Text = "Guide amount to drink : " + guidePerHour + " mls p/hour";
                    objs.MeasureSys = obj.MeasureSys;
                }


            }
            catch (FileNotFoundException)
            {
                // on error of finding local file, Settings Page 
                // must be loaded for configuration 
                Navigation.PushAsync(new Settings());

                // on error reading local file, use default file

                // need a link to the assembly (dll) to get the file
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                // create a stream to access the file
                Stream stream = assembly.GetManifestResourceStream(
                                "waterAppDev2018.Model.LocalStorage.txt");
                using (var reader = new StreamReader(stream))
                {
                    string jsonText = reader.ReadToEnd();
                    jsonToObjects = JsonConvert.DeserializeObject<List<JsonToObject>>(jsonText);
                }

                JsonToObject json = new JsonToObject();
                foreach (var obj in jsonToObjects)
                {
                    json.Weight = obj.Weight;
                    int amountTarget = json.DrinkAmount(json.Weight);
                    targetWaterIntake.Text = "Target : " + amountTarget + " mls";
                    json.WakeUpTime = obj.WakeUpTime;
                    json.SleepTime = obj.SleepTime;
                    double guidePerHour = json.TargetLine(amountTarget);
                    guide.Text = "Guide amount to drink : " + guidePerHour + " mls p/hour";
                    json.MeasureSys = obj.MeasureSys;
                }
            }//catch

        }



        private void AddQuantityButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddWaterQuantity());
        }

        //private void DrinkMeter()
        //{
        //    //MeasurementSystem target = new MeasurementSystem();
        //    //amountTarget = target.DrinkAmount();
        //    //targetWaterIntake.Text = "Target : " + amountTarget + " mls";

        //    //int guideDrank = target.TargetLine();
        //    //guide.Text = "Guide amount drunk : " + guideDrank + " mls";

        //    AddWaterQuantity water = new AddWaterQuantity();
        //    int drank = water.AddWater();
        //    drinkMeter.Text = "Drunk : " + drank + " mls";

        //}

        //private void SetupImages()
        //{
        //    var assembly = typeof(MainPage);
        //    WaterGlass.Source = ImageSource.FromResource("waterAppDev2018.Assets.Images.WaterGlass.jpg", assembly);
        //}

       

        private void addMlsButton_Clicked(object sender, EventArgs e)
        {
            int drunk = AddWater();
            totalDrank += drunk;
            drinkMeter.Text = "Drunk : " + totalDrank + "  mls";
            mlsEntry.Text = String.Empty;
        }

        public int AddWater()
        {
            int drunk;//= int.Parse(mlsEntry.Text);
            drunk = Convert.ToInt32(mlsEntry.Text);
            return drunk;
        }





    }
}
