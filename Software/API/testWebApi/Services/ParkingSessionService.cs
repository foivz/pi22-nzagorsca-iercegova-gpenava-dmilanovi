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
        //ZA DORADITI
        public List<string> GetAvailableParkingSpotsPerDate(string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = GetParkingSessionsPerDate(vrijeme);
                var parkingSpots = context.TmpParkingSpots.ToList();
                List<string> idjevi = new List<string>();
                //string[] vrijemeProsljedeno = vrijeme.Split('T');
                List<string> zaVratiti = new List<string>();
                foreach (var item in parkingSpots)
                {
                    foreach (var item2 in parkingSessions)
                    {
                        string zaListu = "";
                        zaListu = item2.PssParkingSpotId.ToString() + ";" + 1;
                        if(!idjevi.Contains(item2.PssParkingSpotId.ToString()))
                            idjevi.Add(item2.PssParkingSpotId.ToString());
                        zaVratiti.Add(zaListu);
                    }
                }
                foreach (var item in parkingSpots)
                {
                    if (!idjevi.Contains(item.SptParkingSpotId.ToString()))
                    {
                        string zaListu = "";
                        zaListu = item.SptParkingSpotId.ToString() + ";" + 0;
                    }
                }
                return zaVratiti;
            }
        }

        public List<TmpParkingSession> GetParkingSessionsPerDate(string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                string[] razdvojenoVrijeme = vrijeme.Split('T');
                string[] razdvojeniSatIMinute = razdvojenoVrijeme[1].Split(':');
                string datumZaTrazenje = razdvojenoVrijeme[0] + " " + razdvojenoVrijeme[1] + ":00.0000000 +01:00";

                var parkingSessions = context.ParkingSessions
                    .FromSqlRaw($"select * from parking_sessions where pss_start_time <= '{datumZaTrazenje}' AND pss_end_time >= '{datumZaTrazenje}';")
                    .ToList();

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
