using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatistikaController : Controller
    {
        private readonly ParkingSpaceService _parkingSpaceService;
        private readonly ParkingSessionService _parkingSessionService;
        private readonly ParkingSpotService _parkingSpotService;
        private readonly ParkingUsersService _parkingUserService;
        private readonly ParkingSensorService _parkingSensorService;
        public StatistikaController(ParkingSpaceService parkingSpaceService, ParkingUsersService parkingUserService, ParkingSessionService parkingSessionService, ParkingSpotService parkingSpotService, ParkingSensorService parkingSensorService)
        {
            _parkingSpaceService = parkingSpaceService;
            _parkingSessionService = parkingSessionService;
            _parkingSpotService = parkingSpotService;
            _parkingUserService = parkingUserService;
            _parkingSensorService = parkingSensorService;
        }

        [HttpGet]
        [Route("allParkingSensors")]
        public async Task<ActionResult<List<TmpSensor>>> GetParkingSensors()
        {
            return _parkingSensorService.GetAllParkingSensors();
        }

        [HttpGet]
        [Route("randomSenzori")]
        public async Task<ActionResult<List<TmpSensor>>> GetRandomSensors()
        {
            List<TmpSensor> sviSenzori = _parkingSensorService.GetAllParkingSensors();
            List<TmpSensor> pedesetRandomSenzora = new List<TmpSensor>();
            for(int i = 0; i < 50; i++)
            {
                foreach (TmpSensor item in sviSenzori)
                {
                    Random random = new Random();
                    int trazeniId = random.Next(6320, 15000);
                    if (trazeniId == item.SnrSensorId)
                        pedesetRandomSenzora.Add(item);
                }
            }

            return pedesetRandomSenzora;
        }

        [HttpGet]
        [Route("specificParkingSensor")]
        public async Task<ActionResult<List<TmpSensor>>> GetSpecificParkingSensor(int Id)
        {
            return _parkingSensorService.GetSpecificParkingSensor(Id);
        }

        [HttpGet]
        [Route("tipParkirnihMjesta")]
        public string GetParkingSpots()
        {
            var parkirniSpotovi = _parkingSpotService.GetAllParkingSpots();
            int brojRegular = 0;
            int brojHendikep = 0;
            foreach (var item in parkirniSpotovi)
            {
                if (item.SptSpotType == "Regular")
                    brojRegular++;
                else
                    brojHendikep++;
            }
            string parkirnaMjesta = brojRegular + ";" + brojHendikep;
            return parkirnaMjesta;
        }


        [HttpGet]
        [Route("brojSlobodnihMjestaPoParkirnomSpaceu")]
        public async Task<ActionResult<List<string>>> brojSlobodnihMjestaPoParkirnomSpaceu()
        {
            var parkingSpaces = _parkingSpaceService.GetAllParkingSpaces();
            var parkingSpots = _parkingSpotService.GetAllParkingSpots();
            List<string> povratniStringSvihPodataka = new List<string>();
            foreach (var item in parkingSpaces)
            {
                List<TmpParkingSpot> parkirnaMjestaParkirnogSpacea = new List<TmpParkingSpot>();
                int brojOkupiranih = 0;
                int brojSlobodnih = 0;
                foreach (var item2 in parkingSpots)
                {
                    if (item.PspParkingSpaceId == item2.SptParkingSpaceId)
                        parkirnaMjestaParkirnogSpacea.Add(item2);
                }
                foreach (var item3 in parkirnaMjestaParkirnogSpacea)
                {
                    if (item3.SptOccupied == true)
                        brojOkupiranih++;
                    else
                        brojSlobodnih++;
                }
                string povratni = "";
                povratni = item.PspParkingSpaceId + ";" + brojSlobodnih + ";" + brojOkupiranih;
                povratniStringSvihPodataka.Add(povratni);
            }
            return povratniStringSvihPodataka;
        }
    }
}
