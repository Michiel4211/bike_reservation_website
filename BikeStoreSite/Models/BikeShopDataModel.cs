using Bike_store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BikeStoreSite.Models
{
    public class BikeShopDataModel : DbContext
    {
        public BikeShopDataModel() : base("name=BikeShopDataModel")
        {
        }

        public virtual DbSet<Bike_store.Store> Stores { get; set; }

        public virtual DbSet<Bike_store.Customer> Customers { get; set; }

        public virtual DbSet<Bike_store.Reservation> Reservations { get; set; }

        public virtual DbSet<Bike_store.Bike> Bikes { get; set; }
    }
}