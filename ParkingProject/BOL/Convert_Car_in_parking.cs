using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
namespace BOL
{
    public  class Convert_Car_in_parking
    {
        ParkingEntities db = new ParkingEntities();
        public static Car_in_parking_Entity convertToEntity(Car_in_parking c)
        {
            return new Car_in_parking_Entity()
            {
                c_id = c.c_id,
                c_parkingId = c.c_parkingId,
                c_car_number = c.Car.car_number,
                c_date = c.c_date,
                c_date_end = c.c_date_end,
                c_endHour = c.c_endHour,
                c_startHour = c.c_startHour
            };
        }
        public static Car_in_parking convertToDal(Car_in_parking_Entity c)
        {
            return new Car_in_parking()
            {
                c_id = c.c_id,
                c_parkingId = c.c_parkingId,
                c_car_id=c.c_id,
                c_startHour = c.c_startHour,
                c_endHour = c.c_endHour,
                c_date = c.c_date,
                c_date_end = c.c_date_end,
             // Parking = db.Parkings.FirstOrDefault(p => p.p_Id == c.c_parkingId)
                // להוסיף קשר גומלין לcar
            };
        }
    }
}
