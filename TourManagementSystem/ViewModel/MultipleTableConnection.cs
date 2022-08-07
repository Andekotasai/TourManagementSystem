using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourManagementSystem.Models;

namespace TourManagementSystem.ViewModel
{
    public class MultipleTableConnection
    {
        public Booking Bookings { get; set; }
        public TourDetail Details { get; set; }
    }
}