//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TourDetail
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string TourPlaceDetails { get; set; }
        public string HotelName { get; set; }
        public string HotelDetails { get; set; }
        public string VehicleDetails { get; set; }
        public double TravellingCost { get; set; }
        public double HostelCost { get; set; }
        public double FoodCost { get; set; }
        public System.DateTime LeaveDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
    }
}
