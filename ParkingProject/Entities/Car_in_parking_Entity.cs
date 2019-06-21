using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Car_in_parking_Entity
    {
        public int c_id { get; set; }
        public string c_car_number { get; set; }
        public int c_parkingId { get; set; }
        public Nullable<System.DateTime> c_date { get; set; }
        public System.TimeSpan c_startHour { get; set; }
        public Nullable<System.TimeSpan> c_endHour { get; set; }
        public System.DateTime c_date_end { get; set; }
    }
}
