using Bike_store;
using BikeStoreSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BikeStoreSite.ViewModel
{
    public class ReservationViewModel
    {
        public BikeShopDataModel db { get; set; }
        public Store Store { get; set; }
        public IEnumerable<Reservation> AllReservations { get; set; }
        public SelectList BikeSelection { get; set; }
        public Reservation reservation { get; set; }
        public  Customer Customers { get; set; }
        public int SelectedBike { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DropOffDate { get; set; }
        public double Price { get; set; }

        public ReservationViewModel()
        {
            PickUpDate = DateTime.Today;
            DropOffDate = DateTime.Today;

            Price = 0;

            Customers = new Customer();
        }

        public void Save()
        {
            /*            using (var db = new BikeShopDataModel())
                        {

                        }*/

            db.Customers.Add(Customers);
            db.SaveChanges();

            reservation = new Reservation();

            reservation.P_Customer = Customers;
            reservation.P_ReservedBikes.Add(db.Bikes.Find(SelectedBike));
            reservation.P_StartDate = PickUpDate.ToString();
            reservation.P_EndDate = DropOffDate.ToString();
            reservation.P_StoreLocation = Store;
            reservation.P_Price = ((DropOffDate - PickUpDate).TotalDays * db.Bikes.Find(SelectedBike).P_DayRate);

            db.Reservations.Add(reservation);
            db.SaveChanges();

        }

        public void SaveCustomer(Customer cus)
        {

        }
    }
}