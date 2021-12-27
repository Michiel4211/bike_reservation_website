using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_store
{
    public class Bike : INotifyPropertyChanged
    {
        private string _Name;
        private E_Brand _BikeBrand;
        private E_BikeType _BikeType;
        private E_BikeGender _BikeGender;
        private E_BikeSize _BikeSize;
        private double _HourRate;
        private double _DayRate;
        private string _Discription;
        private static int P_TotalBikesCreated;

        //Public variables you can use and set
        public int BikeId { get; set; }
        public string P_Name { get => _Name;
            set {
                _Name = value;
                Notify("P_Name");
            }
        }
        public E_Brand P_BikeBrand { get => _BikeBrand; set => _BikeBrand = value; }
        public E_BikeType P_BikeType { get => _BikeType; set => _BikeType = value; }
        public E_BikeGender P_BikeGender { get => _BikeGender; set => _BikeGender = value; }
        public E_BikeSize P_BikeSize { get => _BikeSize; set => _BikeSize = value; }
        public double P_HourRate { get => _HourRate; set => _HourRate = value; }
        public double P_DayRate { get => _DayRate; set => _DayRate = value; }
        public string P_Discription { get => _Discription; set => _Discription = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Notify function
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Bike() => P_TotalBikesCreated += 1;

        public static int TotalBikesCreated() => P_TotalBikesCreated;
    }

    public enum E_BikeType
    {
        Electric,
        Semi,
        Normal
    }

    public enum E_BikeGender
    {
        Male,
        Female
    }

    public enum E_BikeSize
    {
        Large,
        Medium,
        Small
    }

    public enum E_Brand
    {
        Michielsbike,
        Stevens,
        Kaia,
        Edos
    }
}
