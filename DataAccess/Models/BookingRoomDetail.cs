using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class BookingRoomDetail
    {
        public string IdbookingRoomDetail { get; set; } = null!;
        public string Idbill { get; set; } = null!;
        public string Idroom { get; set; } = null!;
        public decimal Price { get; set; }
        public int? St { get; set; }

        public virtual Bill IdbillNavigation { get; set; } = null!;
        public virtual Room IdroomNavigation { get; set; } = null!;
    }
}
