using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaciIzBaze.Services
{
    public class ParkingSensorService
    {
        public List<TmpSensor> GetAllParkingSensors()
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSensors = context.TmpSensors.ToList();
                return parkingSensors;
            }
        }

    }
}
