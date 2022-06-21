global using PodaciIzBaze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaciIzBaze.Services
{
    public class ParkingSpaceService
    {
        public List<TmpParkingSpace> GetAllParkingSpaces()
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpaces = context.TmpParkingSpaces.ToList();
                return parkingSpaces;
            }
        }
        public List<TmpParkingSpace> GetSpecificParkingSpace(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpaces = context.TmpParkingSpaces.Where(x => x.PspParkingSpaceId == id).ToList();
                return (List<TmpParkingSpace>)parkingSpaces;
            }
        }
    }
}
