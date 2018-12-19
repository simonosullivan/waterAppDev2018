using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018
{
    public class RecordWaterDay
    {
        public int day;
        public int month;
        public int year;
        public int totalDrank;

        public RecordWaterDay()
        {
            RecordWaterDay d = new RecordWaterDay(this.day, this.month, this.year, this.totalDrank);
        }

        public RecordWaterDay(int day, int month, int totalDrank, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.totalDrank = totalDrank;
        }
    }
}
