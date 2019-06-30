using System;
using System.Collections.Generic;
using System.Text;

namespace HimaanApp.Models
{
    /// <summary>
    /// Model for offered ride
    /// </summary>
    public class Offer
    {
        public string userId{ get; set; }
        public string offerFrom { get; set; }
        public string offerTo { get; set; }
        public DateTime offerDate { get; set; }
        public string offerDescription { get; set; }
        public int offerFreeSeats { get; set; }
    }
}
