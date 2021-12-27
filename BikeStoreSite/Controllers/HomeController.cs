using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStoreSite.Models;
using Bike_store;
using BikeStoreSite.ViewModel;

namespace BikeStoreSite.Controllers
{
    public class HomeController : Controller
    {
        private BikeShopDataModel db = new BikeShopDataModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
