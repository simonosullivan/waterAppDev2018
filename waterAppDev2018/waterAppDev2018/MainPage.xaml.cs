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
        public List<RecordWaterDay> record = new List<RecordWaterDay>();
        public List<JsonToObject> jsonToObjects = new List<JsonToObject>();
        public int date;
        public int day=0;
        public int month=0;
        public int year = 2018;


        public MainPage()
        {
            InitializeComponent();

            // get current date
            string d = DateTime.Now.ToString("dd");
            string m = DateTime.Now.ToString("MM");
            string y = DateTime.Now.ToString("yyyy");

            // change to ints
            int day = Convert.ToInt32(d);
            int month = Convert.ToInt32(m);
            int year = Convert.ToInt32(y);

            // first, to see if entry entered today and if is , show what drank earlier
            ReadWaterFile(); 

            // compare current date with last entry date
            CompareDate(day, month, year);
            

            // Read for target amount and how much to drink per hour (based on hours awake)
            ReadFromJson();

        }

        private void ReadWaterFile()
        {
            try
            {
                // Read the list from water file
                string path = Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, "RecordWater_Day.txt");

                // use a stream reader to read the text out to file
                using (var streamReader = new StreamReader(filename, false))
                {
                    string jsonText = streamReader.ReadToEnd();
                    record = JsonConvert.DeserializeObject<List<RecordWaterDay>>(jsonText);
                }
                RecordWaterDay objs = new RecordWaterDay();
                foreach (var obj in record)
                {
                    this.day = obj.day;
                    this.month = obj.month;
                    this.totalDrank = obj.totalDrank;
                }
            }
            catch (FileNotFoundException)
            {
                // need a link to the assembly (dll) to get the file
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                // create a stream to access the file
                Stream stream = assembly.GetManifestResourceStream(
                                "waterAppDev2018.Model.WaterStore.txt");
                using (var reader = new StreamReader(stream))
                {
                    string jsonText = reader.ReadToEnd();
                    record = JsonConvert.DeserializeObject<List<RecordWaterDay>>(jsonText);
                }

                RecordWaterDay wd = new RecordWaterDay();
                foreach (var obj in record)
                {
                    this.day = obj.day; // all 0
                    this.month = obj.month;
                    this.year = obj.year;
                    this.totalDrank = obj.totalDrank;
                }
            }
            
        }


        private void CompareDate(int day, int month, int year)
        {
            if (day > this.day || month > this.month || year > this.year)
            {
                // new object for new day 
                this.totalDrank = 0;
                drinkMeter.Text = "Have you drunk any water yet?";
                // set last entry date to current date
                this.day = day;
                this.month = month;
                this.year = year;

            }
            else if (day == this.day)
            {
                // same day, load what drank earlier today
                drinkMeter.Text = "Drunk : " + this.totalDrank;
            }
        }

        private void WriteWaterFile()
        {
            RecordWaterDay recordWater = new RecordWaterDay();
            recordWater.day = this.day;
            recordWater.month = this.month;
            recordWater.totalDrank = this.totalDrank;
            record.Add(recordWater);  // filling and adding entry to list

            // write the list to a local file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, "RecordWater_Day.txt");
            // use a stream writer to write the text out to file
            using (var streamWriter = new StreamWriter(filename, false))
            {
                // serialise the dogs list to a string using the jsonconvert library 
                string jsonText = JsonConvert.SerializeObject(record);
                streamWriter.WriteLine(jsonText);
            }
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

                // create object to assign values from list into variables 
                JsonToObject objs = new JsonToObject();
                foreach (var obj in jsonToObjects) 
                {   // used to run throw list and take latest entry into list (most up-to-date)

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
                // on error of finding local file , 
                // Settings Page must be loaded for configuration 
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

                // create object to assign values from list into variables 
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
       
        private void addMlsButton_Clicked(object sender, EventArgs e)
        {
            int drunk = AddWater(); // method gets entry from mls text box
            totalDrank += drunk;
            drinkMeter.Text = "Drunk : " + totalDrank + "  mls";
            mlsEntry.Text = String.Empty;

            // Message for Hitting daily target
            if(totalDrank >= amountTarget)
            {
                DisplayAlert("You have reached your goal", "Drunk daily amount, Congratulations", "Thanks");
            }

            WriteWaterFile(); // writes to json file every entry to keep it updated
        }

        public int AddWater()
        {
            int drunk;
            drunk = Convert.ToInt32(mlsEntry.Text);
            return drunk;
        }





    }
}
