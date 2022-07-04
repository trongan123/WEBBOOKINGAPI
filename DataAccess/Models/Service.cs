using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Service
    {
        public Service()
        {
            BookingSeviceDetails = new HashSet<BookingSeviceDetail>();
        }

        public string Idservice { get; set; } = null!;
        public string NameService { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BookingSeviceDetail> BookingSeviceDetails { get; set; }
    }
}
