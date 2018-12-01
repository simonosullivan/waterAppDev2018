using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace waterAppDev2018.Model
{
    public class DbClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int DbWeight { get; set; }
        public int DbWakeUp { get; set; }
        public int DbBedTime { get; set; }
        public string DbMeasureSys { get; set; }

    }
}
