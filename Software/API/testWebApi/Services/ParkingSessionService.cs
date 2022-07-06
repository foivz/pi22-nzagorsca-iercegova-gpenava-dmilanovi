using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository;
using WebAPI.Repository.Models;

namespace WebAPI.Services
{
    public class ParkingSessionService
    {
        public List<TmpParkingSession> GetParkingSessionsPerParkingSpot(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == id).ToList();
                return parkingSessions;
            }
        }
        public List<TmpParkingSession> GetParkingSessionsPerParkingSpotWithDate(int id, string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == id).ToList();
                List<TmpParkingSession> zaVratiti = new List<TmpParkingSession>();
                foreach (var item in parkingSessions)
                {
                    string[] datumItema = item.PssStartTime.Split(' ');
                    for(int i = 0; i < 1; i++)
                    {
                        string[] godinaMjesecDan = datumItema[i].Split('-');
                        string[] prosljedeniGodinaMjesecDan = vrijeme.ToString().Split('-');
                        if (godinaMjesecDan[1] == prosljedeniGodinaMjesecDan[1] && godinaMjesecDan[2] == prosljedeniGodinaMjesecDan[2])
                            zaVratiti.Add(item);
                    }
                }
                return zaVratiti;
            }
        }

        public List<string> GetAvailableParkingSpotsPerDate(string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssStartTime.StartsWith(vrijeme)).ToList();
                var parkingSpots = context.TmpParkingSpots.ToList();
                //string[] vrijemeProsljedeno = vrijeme.Split('T');
                List<string> zaVratiti = new List<string>();
                foreach (var item in parkingSpots)
                {
                    foreach (var item2 in parkingSessions)
                    {
                        string zaListu = "";
                        if(item.SptParkingSpotId == item2.PssParkingSpotId)
                        {
                            zaListu = item.SptParkingSpotId.ToString() + ";" + 1;
                            zaVratiti.Add(zaListu);
                        }
                        else
                        {
                            zaListu = item.SptParkingSpotId.ToString() + ";" + 0;
                            zaVratiti.Add(zaListu);
                        }
                    }
                }
                return zaVratiti;
            }
        }

        public List<TmpParkingSession> GetParkingSessionsPerDate(string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssStartTime.StartsWith(vrijeme)).ToList();
                return parkingSessions;
            }
        }

        public List<TmpParkingSession> GetSpecificParkingSession(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSessionId == id).ToList();
                return (List<TmpParkingSession>)parkingSessions;
            }
        }
        public List<TmpParkingSession> GetAllParkingSessionsForParkingSpace(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpotsZaParkirniSpace = context.TmpParkingSpots.Where(x => x.SptParkingSpaceId == id).ToList();
                List<TmpParkingSession> parkingSessionsZaParkirniSpace = new List<TmpParkingSession>();
                foreach (var item in parkingSpotsZaParkirniSpace)
                {
                    List<TmpParkingSession> parkingSessions = new List<TmpParkingSession>();
                    parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == item.SptParkingSpotId).ToList();
                    foreach (var item2 in parkingSessions)
                    {
                        parkingSessionsZaParkirniSpace.Add(item2);
                    }
                }
                return (List<TmpParkingSession>)parkingSessionsZaParkirniSpace;
            }
        }
    }
}
