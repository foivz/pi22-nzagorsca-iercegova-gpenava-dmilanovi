using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaciIzBaze.Services
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

    }
}
