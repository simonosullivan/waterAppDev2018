using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018
{
    public class RecordWaterDay
    {
        public int day;
        public int month;
        public int totalDrank;

        public RecordWaterDay()
        {
            RecordWaterDay d = new RecordWaterDay(this.day, this.month, this.totalDrank);
        }

        public RecordWaterDay(int day, int month, int totalDrank)
        {
            this.day = day;
            this.month = month;
            this.totalDrank = totalDrank;
        }
    }
}
