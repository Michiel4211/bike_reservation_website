using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_store
{
    public class Store : INotifyPropertyChanged
    {
        //Private vars
        private ObservableCollection<Bike> _BikeInventory = new ObservableCollection<Bike>();
        private string _StreetName;
        private string _City;
        private ObservableCollection<Reservation> _ReservationList = new ObservableCollection<Reservation>();
        private ObservableCollection<Customer> _CustomerList = new ObservableCollection<Customer>();
        private int _MaxCapacity;

        //Public vars
        public int StoreId { get; set; }

        [Display(Name = "Aantal fietsen")]
        public virtual ObservableCollection<Bike> P_BikeInventory { get => _BikeInventory; set => _BikeInventory = value; }

        [Display(Name = "Straat")]
        public string P_StreetName { get => _StreetName; 
            set 
            {
                _StreetName = value;
                Notify("P_StreetName");
            }
        }
        [Display(Name = "Stad")]
        public string P_City { get => _City; 
            set 
            { 
                _City = value;
                Notify("P_City");
            } 
        }
        public virtual ObservableCollection<Reservation> P_ReservationList { get => _ReservationList; set => _ReservationList = value; }
        public int P_MaxCapacity { get => _MaxCapacity; set => _MaxCapacity = value; }
        public virtual ObservableCollection<Customer> P_CustomerList { get => _CustomerList; set => _CustomerList = value; }
        public object P_ReservedBikes { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Notify function
        public void Notify(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
