using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourManagementSystem.Models;

namespace TourManagementSystem.Controllers
{
    public class AdminTourDetailsController : Controller
    {
        private TourManagementSystemEntities db = new TourManagementSystemEntities();

        // GET: AdminTourDetails
        public ActionResult Index()
        {
            return View(db.TourDetails.ToList());
        }

        // GET: AdminTourDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDetail tourDetail = db.TourDetails.Find(id);
            if (tourDetail == null)
            {
                return HttpNotFound();
            }
            return View(tourDetail);
        }

        // GET: AdminTourDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTourDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TourName,TourPlaceDetails,HotelName,HotelDetails,VehicleDetails,TravellingCost,HostelCost,FoodCost,LeaveDate,ReturnDate")] TourDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                db.TourDetails.Add(tourDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourDetail);
        }

        // GET: AdminTourDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDetail tourDetail = db.TourDetails.Find(id);
            if (tourDetail == null)
            {
                return HttpNotFound();
            }
            return View(tourDetail);
        }

        // POST: AdminTourDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TourName,TourPlaceDetails,HotelName,HotelDetails,VehicleDetails,TravellingCost,HostelCost,FoodCost,LeaveDate,ReturnDate")] TourDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourDetail);
        }

        // GET: AdminTourDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDetail tourDetail = db.TourDetails.Find(id);
            if (tourDetail == null)
            {
                return HttpNotFound();
            }
            return View(tourDetail);
        }

        // POST: AdminTourDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourDetail tourDetail = db.TourDetails.Find(id);
            db.TourDetails.Remove(tourDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
