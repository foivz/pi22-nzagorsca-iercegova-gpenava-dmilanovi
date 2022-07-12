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


        public List<TmpSensor> GetSensorsForParkingSpace(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpot = context.TmpSensors.FromSqlRaw($"select distinct top 10 " +
                    $"snr_sensor_id, snr_ble_mac, snr_nbps_packets_sent, snr_nbps_battery_voltage, snr_nbps_battery_level, snr_nbps_network_signal, " +
                    $"snr_nbps_rsrq_value, snr_nbps_cell_id, snr_current_magdata_time from dbo.tmp_sensor INNER JOIN dbo.parking_sessions " +
                    $"ON dbo.parking_sessions.pss_sensor_id = dbo.tmp_sensor.snr_sensor_id INNER JOIN dbo.tmp_parking_spot ON dbo.parking_sessions.pss_parking_spot_id =" +
                    $" dbo.tmp_parking_spot.spt_parking_spot_id INNER JOIN dbo.tmp_parking_space ON dbo.tmp_parking_space.psp_parking_space_id = " +
                    $"dbo.tmp_parking_spot.spt_parking_space_id WHERE dbo.tmp_parking_space.psp_parking_space_id = '{id}' ORDER BY snr_nbps_battery_level asc;").ToList();
                return parkingSpot;
            }
        }

        public List<TmpParkingSpaceLoad> GetPercentageForParkingSpace(int id, string datum)
        {
            using (var context = new PI2201_DBContext())
            {
                string[] razdvojeniDatum = datum.Split('T');
                var parkingSpot = context.TmpParkingSpaceLoads.Where(x => x.PslDatetime.ToString().StartsWith(razdvojeniDatum[0]) && x.PslParkingSpaceId == id).ToList();
                return parkingSpot;
            }   
        }
    }
}
