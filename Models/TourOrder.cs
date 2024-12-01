// using System;
// using System.Collections.Generic;
// using System.Text.Json.Serialization;

// namespace TourFlowBE.Models;

// public partial class TourOrder
// {
//     public int Id { get; set; }

//     public DateTime? BookDate { get; set; }

  
//     public int TourflowUserId { get; set; }

//     public int TourBooked { get; set; }

//     public int? Slots { get; set; }

//     public double? TotalPrice { get; set; }

//     public bool? Paid { get; set; }

//     [JsonIgnore]
//     public virtual Tour TourBookedNavigation { get; set; } = null;

//     [JsonIgnore]
//     public virtual TourflowUser TourflowUser { get; set; } = null;
// }
using System;
using System.Text.Json.Serialization;

namespace TourFlowBE.Models
{
    public partial class TourOrder
    {
        public int Id { get; set; }

        public DateTime? BookDate { get; set; }
 
        public int TourflowUserId { get; set; }  // This should be the foreign key, not the navigation property
 
        public int TourBooked { get; set; }  // This should be the foreign key, not the navigation property

        public int? Slots { get; set; }

        public double? TotalPrice { get; set; }

        public bool? Paid { get; set; }

        [JsonIgnore]
        public virtual Tour TourBookedNavigation { get; set; } // Ignore in API binding

        // [JsonIgnore]
        public virtual TourflowUser TourflowUser { get; set; }
}
}