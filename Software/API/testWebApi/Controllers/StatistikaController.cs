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
    }
}
