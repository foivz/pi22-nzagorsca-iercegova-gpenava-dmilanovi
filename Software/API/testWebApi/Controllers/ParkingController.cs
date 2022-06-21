using Microsoft.AspNetCore.Mvc;
using PodaciIzBaze.Models;
using PodaciIzBaze.Services;

namespace testWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingSpaceService _parkingSpaceService;
        private readonly ParkingSessionService _parkingSessionService;
        private readonly ParkingSpotService _parkingSpotService;
        private readonly ParkingUsersService _parkingUserService;
        private readonly ParkingSensorService _parkingSensorService;
        public ParkingController(ParkingSpaceService parkingSpaceService, ParkingUsersService parkingUserService, ParkingSessionService parkingSessionService, ParkingSpotService parkingSpotService, ParkingSensorService parkingSensorService)
        {
            _parkingSpaceService = parkingSpaceService;
            _parkingSessionService = parkingSessionService;
            _parkingSpotService = parkingSpotService;
            _parkingUserService = parkingUserService;
            _parkingSensorService = parkingSensorService;
        }

        [HttpGet]
        [Route("allParkingSpaces")]
        public async Task<ActionResult<List<TmpParkingSpace>>> GetParkingSpaces()
        {
            return _parkingSpaceService.GetAllParkingSpaces();
        }

        [HttpGet]
        [Route("specificParkingSpace")]
        public async Task<ActionResult<List<TmpParkingSpace>>> GetSpecificParkingSpace(int id)
        {
            return _parkingSpaceService.GetSpecificParkingSpace(id);
        }
    }
}

