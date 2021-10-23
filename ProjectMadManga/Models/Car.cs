using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMadManga
{
    public class Car
    {
        //Primary Key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Main detail
        public string CarName { get; set; }
        public string CarImage { get; set; }
        //Stats
        public double CarAccel { get; set; }
        public double CarTopSpeed { get; set; }
        public double CarHandeling { get; set; }
        public double CarBraking { get; set; }
        public double CarWanted { get; set; }
        public string CarDetail { get; set; }     
    }
}
