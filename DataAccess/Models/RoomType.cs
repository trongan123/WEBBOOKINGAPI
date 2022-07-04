using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public string IdroomType { get; set; } = null!;
        public string NameRoomType { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
