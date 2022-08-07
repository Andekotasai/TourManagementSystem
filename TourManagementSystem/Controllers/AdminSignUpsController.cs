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
    public class AdminSignUpsController : Controller
    {
        private TourManagementSystemEntities db = new TourManagementSystemEntities();

        // GET: AdminSignUps
        public ActionResult Index()
        {
            return View(db.SignUps.ToList());
        }

        // GET: AdminSignUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // GET: AdminSignUps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSignUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Gender,MobileNumber,Password,ConfirmPassword")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                db.SignUps.Add(signUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signUp);
        }

        // GET: AdminSignUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // POST: AdminSignUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Gender,MobileNumber,Password,ConfirmPassword")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signUp);
        }

        // GET: AdminSignUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // POST: AdminSignUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SignUp signUp = db.SignUps.Find(id);
            db.SignUps.Remove(signUp);
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
