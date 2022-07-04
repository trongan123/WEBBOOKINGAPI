using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class BookingSeviceDetail
    {
        public string IdbookingSeviceDetail { get; set; } = null!;
        public string? Idbill { get; set; }
        public string? Idsevice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? St { get; set; }

        public virtual Bill? IdbillNavigation { get; set; }
        public virtual Service? IdseviceNavigation { get; set; }
    }
}
