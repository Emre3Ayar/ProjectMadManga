using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectMadManga
{
    public class Car: INotifyPropertyChanged
    {
        //Primary Key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Main detail
        private string _carname;
        public string CarName { get => _carname;
            set
            {
                _carname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CarName)));
            }
        }
        public string CarImage { get; set; }
        //Stats
        public double CarAccel { get; set; }
        public double CarTopSpeed { get; set; }
        public double CarHandeling { get; set; }
        public double CarBraking { get; set; }
        public double CarWanted { get; set; }
        public string CarDetail { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
