﻿using System;
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
        public List<ParkingSession> GetParkingSessionsPerParkingSpot(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == id).ToList();
                return parkingSessions;
            }
        }
        public List<ParkingSession> GetParkingSessionsPerParkingSpotWithDate(int id, string vrijeme)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == id).ToList();
                List<ParkingSession> zaVratiti = new List<ParkingSession>();
                foreach (var item in parkingSessions)
                {
                    string[] datumItema = item.PssStartTime.Split(' ');
                    for (int i = 0; i < 1; i++)
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
                        if (!idjevi.Contains(item2.PssParkingSpotId.ToString()))
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

        public List<ParkingSession> GetParkingSessionsPerDate(string vrijeme)
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

        public List<ParkingSession> GetSpecificParkingSession(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSessionId == id).ToList();
                return (List<ParkingSession>)parkingSessions;
            }
        }
        public List<ParkingSession> GetAllParkingSessionsForParkingSpace(int id, string datum)
        {
            using (var context = new PI2201_DBContext())
            {
                string[] razdvojenDatum = datum.Split('T');
                string[] razdvojenGodinaMjesecDan = razdvojenDatum[0].Split('-');
                string noviMjesec = "";
                if (int.Parse(razdvojenGodinaMjesecDan[1]) > 1)
                {
                    noviMjesec = (int.Parse(razdvojenGodinaMjesecDan[1]) - 1).ToString();
                }
                else
                {
                    noviMjesec = "1";
                    razdvojenGodinaMjesecDan[2] = "01";
                }
                string noviDatum = razdvojenGodinaMjesecDan[0] + "-0" + noviMjesec + '-' + razdvojenGodinaMjesecDan[2] + ' ' + razdvojenDatum[1];
                var parkingSessionsPerParkingSpotsPerParkingSpace = context.ParkingSessions
                    .FromSqlRaw($"select * from parking_sessions INNER JOIN tmp_parking_spot on parking_sessions.pss_parking_spot_id = tmp_parking_spot.spt_parking_spot_id " +
                    $"WHERE tmp_parking_spot.spt_parking_space_id = '{id}' AND parking_sessions.pss_end_time BETWEEN '{noviDatum}' AND '{datum}';")
                    .ToList();
                return parkingSessionsPerParkingSpotsPerParkingSpace;
            }
        }
        public List<string> CalculatePercentageOfParking(int id, string datum)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessionsPerParkingSpotsPerParkingSpace = GetAllParkingSessionsForParkingSpace(id, datum);
                var parkingSpotsForParkingSpace = context.TmpParkingSpots.Where(x => x.SptParkingSpaceId == id).ToList();
                float brojSatiProvedenoParkirano = 0;
                List<string> postotak = new List<string>();
                float i = parkingSpotsForParkingSpace.Count();
                foreach (var item in parkingSessionsPerParkingSpotsPerParkingSpace)
                {

                    string[] razdvojenoPocetnoVrijeme = item.PssStartTime.Split(' ');
                    string[] razdvojenoZavrsnoVrijeme = item.PssEndTime.Split(' ');

                    string[] pocetniDatumRazdvojen = razdvojenoPocetnoVrijeme[0].Split('-');
                    string[] zavrsniDatumRazdvojen = razdvojenoZavrsnoVrijeme[0].Split('-');

                    string[] pocetniSatiRazdvojeno = razdvojenoPocetnoVrijeme[1].Split(':');
                    string[] zavrsniSatiRazdvojeno = razdvojenoZavrsnoVrijeme[1].Split(':');

                    DateTime pocetniDatum = new DateTime(int.Parse(pocetniDatumRazdvojen[0]), int.Parse(pocetniDatumRazdvojen[1]), int.Parse(pocetniDatumRazdvojen[2]), int.Parse(pocetniSatiRazdvojeno[0]), int.Parse(pocetniSatiRazdvojeno[1]), 00);
                    DateTime zavrsniDatum = new DateTime(int.Parse(zavrsniDatumRazdvojen[0]), int.Parse(zavrsniDatumRazdvojen[1]), int.Parse(zavrsniDatumRazdvojen[2]), int.Parse(zavrsniSatiRazdvojeno[0]), int.Parse(zavrsniSatiRazdvojeno[1]), 00);
                    TimeSpan prosloVremena = zavrsniDatum - pocetniDatum;
                    brojSatiProvedenoParkirano += float.Parse(prosloVremena.TotalHours.ToString());
                }
                float brojSatiUDvaMjesesca = 1460 * i;
                float izracunato = brojSatiProvedenoParkirano / brojSatiUDvaMjesesca * 100;
                postotak.Add(izracunato.ToString());
                return postotak;
            }
        }
        public List<TmpParkingSpaceLoad> GetPercentageForParkingSpaceForDate(int id, string datum)
        {
            using (var context = new PI2201_DBContext())
            {

                string[] razdvojenDatum = datum.Split('T');
                string[] razdvojenDrugiDio = razdvojenDatum[1].Split('.');
                string[] potrebanSat = razdvojenDrugiDio[0].Split(':');
                var parkingSpot = context.TmpParkingSpaceLoads.Where(x => x.PslDatetime.ToString().StartsWith(razdvojenDatum[0] + " " + potrebanSat[0]) && x.PslParkingSpaceId == id).ToList();
                return parkingSpot;
            }
        }

        public List<string> GetFreePercentageForParkingSpaceForDate(string datum)
        {
            using (var context = new PI2201_DBContext())
            {
                string[] razdvojenDatum = datum.Split('T');
                //var parkingSpot = context.TmpParkingSpaceLoads.Where(x => x.PslDatetime.ToString().StartsWith(razdvojenDatum[0] + " " + potrebanSat[0]) && x.PslParkingSpaceId == id).ToList();
                var parkingSpot = context.TmpParkingSpaceLoads.FromSqlRaw($"select * from dbo.tmp_parking_space_load where psl_datetime < '{razdvojenDatum[0] + " " + razdvojenDatum[1]}'").ToList();
                var parkirniSpaceovi = context.TmpParkingSpaces.ToList();
                List<string> zaVratiti = new List<string>();
                foreach (var item in parkirniSpaceovi)
                {
                    double? prosjek = 0;
                    double? brojBrojeva = 0;
                    string djGrgo = "";
                    djGrgo += item.PspLabel;
                    foreach (var item2 in parkingSpot)
                    {
                        if (item.PspParkingSpaceId == item2.PslParkingSpaceId)
                        {
                            prosjek += item2.PslLoad;
                            brojBrojeva++;
                        }
                    }
                    double? prosjekk = prosjek / brojBrojeva;
                    string zaDodati = djGrgo + ";" + prosjekk.ToString();
                    zaVratiti.Add(zaDodati);
                }
                return zaVratiti;
            }
        }
    }
}

