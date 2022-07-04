using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
            Comments = new HashSet<Comment>();
        }
        [Key]
        public string Idacc { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int? St { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
