using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaciIzBaze.Services
{
    public class ParkingSessionService
    {
        public List<TmpParkingSession> GetAllParkingSessions()
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.TmpParkingSessions.ToList();
                return parkingSessions;
            }
        }

    }
}
