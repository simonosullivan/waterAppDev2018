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
	public partial class AddWaterQuantity : ContentPage
	{
		public AddWaterQuantity ()
		{
			InitializeComponent ();
		}

        private void addMlsButton_Clicked(object sender, EventArgs e)
        {
            AddWater();
            Navigation.PushAsync(new MainPage());
            
        }

        public int AddWater()
        {
            int drunk;//= int.Parse(mlsEntry.Text);
            drunk = Convert.ToInt32(mlsEntry.Text);                                    
            return drunk;
        }

        
    }
}