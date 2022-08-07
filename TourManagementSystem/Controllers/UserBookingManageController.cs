using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagementSystem.Models;
using TourManagementSystem.ViewModel;

namespace TourManagementSystem.Controllers
{
    public class UserBookingManageController : Controller
    {
        private TourManagementSystemEntities details = new TourManagementSystemEntities();
        // GET: UserBookingManage
        [HttpGet]
        public ActionResult Dashboard()
        {

            string Email = Session["Email"].ToString();

            var Bookingdata = details.Bookings.Where(x => x.Email == Email).ToList();
            var TourDetailsData = details.TourDetails.ToList();
            var data = from b in Bookingdata
                       join p in TourDetailsData on b.TourName equals p.TourName into table
                       from p in table.DefaultIfEmpty()
                       select new MultipleTableConnection
                       {
                           Bookings = b,
                           Details = p
                       };



            return View(data);


        }
        public ActionResult ManageBooking()
        {
            string Email = Session["Email"].ToString();
            var data = details.Bookings.Where(m => m.Email == Email).ToList();
            return View(data);
        }
        public ActionResult CancelBooking(int id)
        {
            var data = details.Bookings.Where(x => x.Booking_Id == id).SingleOrDefault();
            data.BookingStatus = "Cancelled";
            details.SaveChanges();
            return RedirectToAction("ManageBooking");
        }
        public ActionResult EditDetails(int id)
        {
            Session["Booking_Id"] = id;
            var data = details.Bookings.Where(x => x.Booking_Id == id).SingleOrDefault();
            return View(data);
        }
        public ActionResult Updating(Booking book)
        {
            int id = Int32.Parse(Session["Booking_Id"].ToString());
            var data = details.Bookings.Find(id);
            data.Name = book.Name;
            data.Address = book.Address;
            data.MobileNumber = book.MobileNumber;
            details.SaveChanges();
            return RedirectToAction("ManageBooking");

        }
    }
}