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
using System.Collections.ObjectModel;

namespace BikeStoreSite.Controllers
{
    public class ReservationsController : Controller
    {
        private BikeShopDataModel db = new BikeShopDataModel();

        // GET: Reservations
        public ActionResult Index(int? id)
        {
            ReservationViewModel tempmodel = new ReservationViewModel();
            tempmodel.Store = db.Stores.Find(id);
            tempmodel.AllReservations = tempmodel.Store.P_ReservationList;

            return View(tempmodel);
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create(int id, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Type" : "";
            ViewBag.DateSortParm = sortOrder == "Type" ? "Size" : "Gender";

            ReservationViewModel tempmodel = new ReservationViewModel();
            tempmodel.Store = db.Stores.Find(id);
            tempmodel.AllReservations = tempmodel.Store.P_ReservationList;

            var bikes = tempmodel.Store.P_BikeInventory;

            switch (sortOrder)
            {
                case "Type":
                    bikes = new ObservableCollection<Bike>(bikes.OrderByDescending(i => i.P_BikeType));
                    break;
                case "Size":
                    bikes = new ObservableCollection<Bike>(bikes.OrderByDescending(i => i.P_BikeSize));
                    break;
                case "Gender":
                    bikes = new ObservableCollection<Bike>(bikes.OrderByDescending(i => i.P_BikeGender));
                    break;
                default:
                    bikes = new ObservableCollection<Bike>(bikes.OrderByDescending(i => i.P_Name));
                    break;
            }

            tempmodel.BikeSelection = new SelectList(bikes.ToArray(), "BikeId", "P_Name", selectedValue: id);

            return View(tempmodel);
        }

        [HttpPost]
        public ActionResult Create(ReservationViewModel vm, int id)
        {
            vm.db = db;
            vm.Store = db.Stores.Find(id);
            vm.Save();

            var bikes = vm.Store.P_BikeInventory;

            vm.BikeSelection =  new SelectList(bikes.ToArray(), "BikeId", "P_Name");


            return RedirectToAction("Index", "Home");
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,P_StartDate,P_EndDate,P_PaymentStatus")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            Store store = reservation.P_StoreLocation;
            db.Reservations.Remove(reservation);
            store.P_ReservationList.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
