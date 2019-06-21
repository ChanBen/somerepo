using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using Entities;
namespace BLL
{
    public class BLL_Car_in_parking
    {
        public static ParkingEntities db = new ParkingEntities();

        //הצגת רכבים בחניון מסוים
        public static List<Car_in_parking_Entity> GetAllCars(int parking_id)
        {
            List<Car_in_parking_Entity> carsInParking = new List<Car_in_parking_Entity>();
            foreach (var item in db.Car_in_parking.ToList())
            {
                if (item.c_parkingId == parking_id)
                    carsInParking.Add(Convert_Car_in_parking.convertToEntity(item));
            }
            return carsInParking;
        }

        //הוספת רכב לחניון
        public static void AddCar(Car_in_parking_Entity car)
        {
            db.Car_in_parking.Add(Convert_Car_in_parking.convertToDal(car));
            db.SaveChanges();
        }

        // מחיקת רכב מחניון שהוסר
        public static void DeleteCar(int id_car)
        {
            Car_in_parking car = db.Car_in_parking.Find(id_car);
            db.Car_in_parking.Remove(car);
            db.SaveChanges();
        }

    }
}