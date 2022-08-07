using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagementSystem.Models;

namespace TourManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private TourManagementSystemEntities details = new TourManagementSystemEntities();
        // GET: Admin
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(AdminSignIn admin)
        {
            var data = details.AdminSignIns.ToList();

            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    if (item.UserName == admin.UserName && item.Password == admin.Password)
                    {
                        return RedirectToAction("AdminHomePage");

                    }
                }
            }

            return View("SignIn");

        }
        public ActionResult AdminHomePage()
        {
            ViewBag.TotalBookings = details.Bookings.Count();
            ViewBag.Pending = details.Bookings.Where(b => b.BookingStatus == "BookingPending").Count();
            ViewBag.Completed = details.Bookings.Where(b => b.BookingStatus == "Success").Count();
            ViewBag.Cancelled = details.Bookings.Where(b => b.BookingStatus == "Cancelled").Count();
            ViewBag.NumberOfTours = details.TourDetails.Count();
            ViewBag.TourBookingUsers = details.Bookings.Select(m => m.Email).Distinct().Count();
            ViewBag.Users = details.SignUps.Select(m => m.Email).Distinct().Count();


            return View();
        }
    }
}