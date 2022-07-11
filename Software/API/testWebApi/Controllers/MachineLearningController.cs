using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineLearningController : Controller
    {
        private readonly ParkingSpaceService _parkingSpaceService;
        private readonly ParkingSessionService _parkingSessionService;
        private readonly ParkingSpotService _parkingSpotService;
        private readonly ParkingUsersService _parkingUserService;
        private readonly ParkingSensorService _parkingSensorService;
        public MachineLearningController(ParkingSpaceService parkingSpaceService, ParkingUsersService parkingUserService, ParkingSessionService parkingSessionService, ParkingSpotService parkingSpotService, ParkingSensorService parkingSensorService)
        {
            _parkingSpaceService = parkingSpaceService;
            _parkingSessionService = parkingSessionService;
            _parkingSpotService = parkingSpotService;
            _parkingUserService = parkingUserService;
            _parkingSensorService = parkingSensorService;
        }

        [HttpGet]
        [Route("parkingSessionsForParkingSpace")]
        public async Task<ActionResult<List<ParkingSession>>> GetParkingSessionsForParkingSpace(int id, string datum)
        {
            return _parkingSessionService.GetAllParkingSessionsForParkingSpace(id, datum);
        }

        [HttpGet]
        [Route("PercentageOfParking")]
        public async Task<ActionResult<List<string>>> CalculatePercentageOfParking(int id, string datum)
        {
            return _parkingSessionService.CalculatePercentageOfParking(id, datum);
        }

        //[HttpGet]
        //[Route("parkingSessionsPerParkingSpace")]
        //public async Task<ActionResult<List<TmpParkingSession>>> GetParkingSessionsPerParkingSpace(int id)
        //{
        //    return _parkingSessionService.GetParkingSessionsPerParkingSpot(id);
        //}

    }
}
