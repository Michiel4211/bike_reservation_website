using Newtonsoft.Json;
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
    public class Reservation : INotifyPropertyChanged
    {
        private string _StartDate;
        private string _EndDate;
        private E_PaymentStatuss _PaymentStatus;
        private Store _StoreLocation = new Store();
        private ObservableCollection<Bike> _ReservedBikes = new ObservableCollection<Bike>();

        //Public variables you can use and set
        public int ReservationId { get; set; }
        public virtual Customer P_Customer { get; set; }
        public virtual Store P_StoreLocation { get; set; }
        public virtual ObservableCollection<Bike> P_ReservedBikes { get => _ReservedBikes; set => _ReservedBikes = value; }

        [Display(Name = "Start dag")]
        public string P_StartDate { get => _StartDate; set => _StartDate = value; }

        [Display(Name = "Laatste dag")]
        public string P_EndDate { get => _EndDate; set => _EndDate = value; }

        [Display(Name = "Betaalstatus")]
        public E_PaymentStatuss P_PaymentStatus { get => _PaymentStatus; set => _PaymentStatus = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        [Display(Name = "Prijs")]
        public double P_Price { get; set; }

        //Notify function
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }         
   }
    //Private Enum settings Only public for acces purposes not for setting value
    public enum E_PaymentStatuss
    {
        Unpayed,
        payed,
        Error
    }
}
