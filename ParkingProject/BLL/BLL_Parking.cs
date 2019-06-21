using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using Entities;
using System.Configuration;
using System.Net;

using System.Data;
using System.Xml;
//using Windows.Devices.Geolocation;
namespace BLL
{
    public class BLL_Parking
    {
        public static ParkingEntities db = new ParkingEntities();

        //החזרת רשימת כל החניונים
        public static List<Parking_Entity> GetAllParkings()
        {
            List<Parking_Entity> Parkings = new List<Parking_Entity>();
            foreach (var item in db.Parkings.ToList())
            {
                Parkings.Add(Convert_Parking.convertToEntity(item));
            }
            return Parkings;
        }

        //הוספת חניון
        public static void AddParking(Parking_Entity parking)
        {
            db.Parkings.Add(Convert_Parking.convertToDal(parking));
            db.SaveChanges();
        }

        //מחיקת חניון
        public static void DeleteParking(int parking_id)
        {
            //לפני שמוחקים חניון מוחקים את בטבלת חניונים של מנהל השייכים לו
            foreach (var item in db.Parkings_of_owner.ToList())
            {
                if (item.op_parking_id == parking_id)
                    BLL_Parkings_of_owner.DeleteParkings_of_owner(item.op_parking_id);
            }
            Parking parking = db.Parkings.Find(parking_id);
            db.Parkings.Remove(parking);
            db.SaveChanges();
        } 
        //מחזיר רשימת חניונים לפי קרטריון בחירה
        public static List<Parking_Entity> getParkings_Search(int user_id, decimal latA, decimal longA)
        {
            List<Parking_Entity> searchParking_list = new List<Parking_Entity>();
            //לולאה על כל החניונים חישוב לפי נקודות שלהם
            foreach (var parking in db.Parkings)
            {
                if (parking.p_Lat == latA && parking.p_Long == longA)
                    searchParking_list.Add(Convert_Parking.convertToEntity(parking));
            }

            return searchParking_list;
            //double xDiff = x2 - x1;
            //double yDiff = y2 - y1;
            //return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;

          
            
             //double distance = locA.GetDistanceTo(locB);
            //List<Parking_Entity> searchParking_list = new List<Parking_Entity>();
            //var range = db.Setting_user.Find(user_id).s_range;
            //searchParking_list.Add(Convert_Parking.convertToEntity(item));
            //if (db.Setting_user.Find(user_id).s_choose_criterion == 1)
            //    searchParking_list = searchParking_list.OrderBy(s => s.p_PricesHour).ToList();
            //else if (db.Setting_user.Find(user_id).s_choose_criterion == 2)
            //    searchParking_list = searchParking_list.OrderBy(s => s.p_Lat).ThenBy(p => p.p_Long).ToList();
            //else if (db.Setting_user.Find(user_id).s_choose_criterion == 3)
            //    searchParking_list = searchParking_list.OrderBy(s => s.p_EmptyParkings).ToList();
            //return searchParking_list;
        }
    }
}
