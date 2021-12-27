using Bike_store;
using BikeStoreSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static BikeStoreSite.Controllers.StoresController;

namespace BikeStoreSite.ViewModel
{
    public class HomeViewModel
    {
        private BikeShopDataModel db = new BikeShopDataModel();
        public Store Store { get; set; }
        public Reservation reservation { get; set; }
        public IEnumerable<Store> AllStores { get; set; }

        public HomeViewModel()
        {
            AllStores = db.Stores.Include(s => s.P_BikeInventory);
        }
    }


}