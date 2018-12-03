using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018
{
    public class JsonToObject
    {
        public int Weight;
        public int WakeUpTime;
        public int SleepTime;
        public string MeasureSys;

        public JsonToObject()
        {
                
        }

        public JsonToObject(int weight, int wakeUpTime, int sleepTime, string measureSys)
        {
            this.Weight = weight;
            this.WakeUpTime = wakeUpTime;
            this.SleepTime = sleepTime;
            this.MeasureSys = measureSys;
        }

        public int DrinkAmount()
        {
            int amountTarget;
            if (this.Weight >= 90)
            {
                amountTarget = 2800;
            }
            else if (this.Weight >= 65)
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
    }
}
