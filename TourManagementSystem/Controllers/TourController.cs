using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagementSystem.Models;

namespace TourManagementSystem.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        private TourManagementSystemEntities details = new TourManagementSystemEntities();
        // GET: Tour
        public ActionResult AppInterface()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View("SignIn");
        }
        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult Check(FormCollection formdata)
        {
            //int count = 0;

            var data = details.SignUps.ToList();
            ViewBag.main = formdata["Username"];
            if (ModelState.IsValid)
            {
                foreach (var value in data)
                {
                    if (value.Email == formdata["Username"] && value.Password == formdata["Password"])
                    {

                        Session["Email"] = value.Email;
                        TempData["Email"] = value.Email;

                        return View("Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username and password");


            return View("SignIn");

        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp datafromUser)
        {
            if (ModelState.IsValid)
            {
                details.SignUps.Add(datafromUser);
                details.SaveChanges();
                return View("SignIn");
            }
            return View("SignUp");


        }
        public ActionResult SignOut()
        {
            Session["Email"] = null;
            return RedirectToAction("SignIn");
        }
        public ActionResult Home()
        {


            return View();
        }
        public ActionResult TourPackageDetails()
        {

            var data = details.TouristPackages.ToList();

            return View("TourPackageDetails", data);
        }
        public ActionResult Details(int id)
        {

            var data = details.TourDetails.Where(x => x.Id == id).ToList();

            return View(data);
        }
        // [Route("Tour/Booking/{name}")]
        public ActionResult Booking(int id)
        {

            var particularData = details.TourDetails.Where(x => x.Id == id).SingleOrDefault();
            ViewBag.Id = particularData.Id;
            ViewBag.name = particularData.TourName;
            ViewBag.TotalPrice = particularData.FoodCost + particularData.HostelCost + particularData.TravellingCost;
            ViewBag.LeaveDate = particularData.LeaveDate;
            ViewBag.ReturnDate = particularData.ReturnDate;
            Session["TourName"] = particularData.TourName;

            //for DropDownList
            var data = details.TouristPackages.ToList();
            ViewBag.data = new SelectList(data, "TouristName", "TouristName");

            return View();
        }
        [HttpPost]
        [ActionName("Booking")]
        public ActionResult Final(Booking book)
        {
            book.TourName = Session["TourName"].ToString();

            book.Email = TempData["Email"].ToString();
            //  var data=details.TourDetails.Where(x => x.TourName == book.TourName).Single();
            // double TotalCost = book.NumberOfTickets*(data.HostelCost + data.FoodCost + data.TravellingCost);
            // book.TotalCost = TotalCost;

            if (!ModelState.IsValid)

            {
                book.BookingStatus = "BookingPending";
                details.Bookings.Add(book);
                details.SaveChanges();
                return RedirectToAction("Dashboard", "UserBookingManage");



            }

            book.BookingStatus = "Success";
            details.Bookings.Add(book);
            details.SaveChanges();
            // return RedirectToAction("Dashboard",Email);
            return RedirectToAction("Dashboard", "UserBookingManage");




        }
        public ActionResult VisitPlace()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VisitPlace(FormCollection search)
        {
            string name = search["place"];
            var data = details.TouristPackages.Where(x => x.TouristName == name).SingleOrDefault();
            return View(data);
        }
        /* [HttpGet]
          public ActionResult Dashboard()
            {

                 string Email = Session["Email"].ToString();

                 var Bookingdata = details.BookingDetails.Where(x => x.Email == Email).ToList();
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


            }*/
        /*  public ActionResult ManageBooking()
          {

          }*/
    }
}