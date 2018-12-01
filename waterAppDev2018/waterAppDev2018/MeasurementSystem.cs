using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018
{
    public class MeasurementSystem
    {
        private int selectedIndex;
        private int weight;
        private int wakeUpTime;
        private int sleepTime;
        private int awake;
        private int amountToDrink;
        private int varTargetLine;

        public MeasurementSystem() {}

        public void MeasureSystem(int selectedIndex)
        {
            this.selectedIndex = selectedIndex;
        }

        public void Weight(int weight)
        {
            this.weight = weight;
            
        }

        public void WakeUpTime(object sender)
        {
            this.wakeUpTime = (int)(sender);
        }

        public void SleepTime(object sender)
        {
            this.sleepTime = (int)(sender);
        }

        public int DrinkAmount()
        {
            int amountTarget;
            if (this.weight >= 90)
            {
                amountTarget = 2800;
            }
            else if (this.weight >= 65)
            {
                amountTarget = 2400;
            }
            else
            {
                amountTarget = 2100;
            }


            //DrinkMeter();
            return amountTarget;
        }

        public int TargetLine()
        {
            awake = sleepTime - wakeUpTime;
            this.varTargetLine = amountToDrink / awake;
            return this.varTargetLine;
        }



    }
}
