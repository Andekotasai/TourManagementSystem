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
    public class AdminTouristPackagesController : Controller
    {
        private TourManagementSystemEntities db = new TourManagementSystemEntities();

        // GET: AdminTouristPackages
        public ActionResult Index()
        {
            return View(db.TouristPackages.ToList());
        }

        // GET: AdminTouristPackages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPackage touristPackage = db.TouristPackages.Find(id);
            if (touristPackage == null)
            {
                return HttpNotFound();
            }
            return View(touristPackage);
        }

        // GET: AdminTouristPackages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTouristPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TouristName,Location,Price")] TouristPackage touristPackage)
        {
            if (ModelState.IsValid)
            {
                db.TouristPackages.Add(touristPackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(touristPackage);
        }

        // GET: AdminTouristPackages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPackage touristPackage = db.TouristPackages.Find(id);
            if (touristPackage == null)
            {
                return HttpNotFound();
            }
            return View(touristPackage);
        }

        // POST: AdminTouristPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TouristName,Location,Price")] TouristPackage touristPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(touristPackage);
        }

        // GET: AdminTouristPackages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPackage touristPackage = db.TouristPackages.Find(id);
            if (touristPackage == null)
            {
                return HttpNotFound();
            }
            return View(touristPackage);
        }

        // POST: AdminTouristPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristPackage touristPackage = db.TouristPackages.Find(id);
            db.TouristPackages.Remove(touristPackage);
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
