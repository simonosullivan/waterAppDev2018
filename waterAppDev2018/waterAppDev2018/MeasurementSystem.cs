using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018
{
    public class MeasurementSystem
    {
        private int selectedIndex;
        private int weight;

        public MeasurementSystem() {}

        public void MeasureSystem(int selectedIndex)
        {
            this.selectedIndex = selectedIndex;
        }

        public void Weight(int weight)
        {
            this.weight = weight;
        }

        public int DrinkAmount()
        {
            int amountTarget=0;
            if(this.weight >= 90)
            {
                amountTarget = 2800;
            }else if(this.weight >= 65)
            {
                amountTarget = 2400;
            }
            else
            {
                amountTarget = 2100;
            }
            return amountTarget;
        }



    }
}
