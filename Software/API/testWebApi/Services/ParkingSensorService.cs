using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository;
using WebAPI.Repository.Models;

namespace WebAPI.Services
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
        
        public List<TmpSensor> GetSpecificParkingSensor(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSensor = context.TmpSensors.Where(x => x.SnrSensorId == id).ToList();
                return (List<TmpSensor>)parkingSensor;
            }
        }
    }
}
