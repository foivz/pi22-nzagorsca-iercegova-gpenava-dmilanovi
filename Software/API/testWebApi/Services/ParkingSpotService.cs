using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository;
using WebAPI.Repository.Models;

namespace WebAPI.Services
{
    public class ParkingSpotService
    {
        public List<TmpParkingSpot> GetAllParkingSpots()
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpots = context.TmpParkingSpots.ToList();
                return parkingSpots;
            }
        }
        public List<TmpParkingSpot> GetSpecificParkingSpot(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpot = context.TmpParkingSpots.Where(x => x.SptParkingSpotId == id).ToList();
                return (List<TmpParkingSpot>)parkingSpot;
            }
        }
        public List<TmpParkingSpot> GetSpecificParkingSpotForParkingSpace(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpot = context.TmpParkingSpots.Where(x => x.SptParkingSpaceId == id).ToList();
                return (List<TmpParkingSpot>)parkingSpot;
            }
        }

        public List<string> GetTypeOfParkingSpot(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpot = context.TmpParkingSpots.FromSqlRaw($"SELECT * FROM dbo.tmp_parking_spot WHERE spt_parking_space_id = '{id}';").ToList();
                List<string> zaVratiti = new List<string>();
                int reserved = 0;
                int regular = 0;
                int handicapped = 0;
                int charging = 0;
                int taxi = 0;
                foreach (var item in parkingSpot)
                {
                    if (item.SptSpotType == "Reserved")
                        reserved++;
                    else if (item.SptSpotType == "Regular")
                        regular++;
                    else if (item.SptSpotType == "Handicapped")
                        handicapped++;
                    else if (item.SptSpotType == "Charging")
                        charging++;
                    else
                        taxi++;
                }
                string zaDodati = "";
                if (regular != 0)
                    zaDodati += "Regular:" + regular.ToString() + ";";
                if(reserved != 0)
                    zaDodati += "Reserved:" + reserved.ToString() + ";";
                if(handicapped != 0)
                    zaDodati += "Handicapped:" + handicapped.ToString() + ";";
                if(charging != 0)
                    zaDodati += "Charging:" + charging.ToString() + ";";
                if(taxi != 0)
                    zaDodati += "TAXI:" + taxi.ToString() + ";";
                zaVratiti.Add(zaDodati);
                return zaVratiti;
            }
        }
    }
}
