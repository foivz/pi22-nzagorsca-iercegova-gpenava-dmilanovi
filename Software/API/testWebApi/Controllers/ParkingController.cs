﻿using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository.Models;
using WebAPI.Services;

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

        [HttpGet]
        [Route("parkingSessionsPerParkingSpot")]
        public async Task<ActionResult<List<ParkingSession>>> GetParkingSessionsPerParkingSpot(int id)
        {
            return _parkingSessionService.GetParkingSessionsPerParkingSpot(id);
        }

        [HttpGet]
        [Route("parkingSessionsPerParkingSpotWithinDate")]
        public async Task<ActionResult<List<ParkingSession>>> GetParkingSessionsPerParkingSpotWithinDate(int id, string vrijeme)
        {
            return _parkingSessionService.GetParkingSessionsPerParkingSpotWithDate(id, vrijeme);
        }


        [HttpGet]
        [Route("availableParkingSpotsPerDate")]
        public async Task<ActionResult<List<string>>> GetAvailableParkingSpotsPerDate(string vrijeme)
        {
            return _parkingSessionService.GetAvailableParkingSpotsPerDate(vrijeme);
        }

        [HttpGet]
        [Route("parkingSessionsPerDate")]
        public async Task<ActionResult<List<ParkingSession>>> GetParkingSessionsPerDate(string vrijeme)
        {
            return _parkingSessionService.GetParkingSessionsPerDate(vrijeme);
        }


        [HttpGet]
        [Route("specificParkingSession")]
        public async Task<ActionResult<List<ParkingSession>>> GetSpecificParkingSession(int Id)
        {
            return _parkingSessionService.GetSpecificParkingSession(Id);
        }

        [HttpGet]
        [Route("allParkingSpots")]
        public async Task<ActionResult<List<TmpParkingSpot>>> GetParkingSpots()
        {
            return _parkingSpotService.GetAllParkingSpots();
        }

        [HttpGet]
        [Route("specificParkingSpot")]
        public async Task<ActionResult<List<TmpParkingSpot>>> GetSpecificParkingSpots(int Id)
        {
            return _parkingSpotService.GetSpecificParkingSpot(Id);
        }

        [HttpGet]
        [Route("ParkingSpotsForParkingSpaces")]
        public async Task<ActionResult<List<TmpParkingSpot>>> GetParkingSpotsForParkingSpaces(int Id)
        {
            return _parkingSpotService.GetSpecificParkingSpotForParkingSpace(Id);
        }

        [HttpGet]
        [Route("TypeOfParkingSpotsPerParkingSpace")]
        public async Task<ActionResult<List<string>>> GetTypeOfParkingSpot(int Id)
        {
            return _parkingSpotService.GetTypeOfParkingSpot(Id);
        }


        [HttpGet]
        [Route("SensorsForParkingSpace")]
        public async Task<ActionResult<List<TmpSensor>>> GetSensorsForParkingSpaces(int Id)
        {
            return _parkingSpotService.GetSensorsForParkingSpace(Id);
        }


        [HttpGet]
        [Route("PercentageForParkingSpace")]
        public async Task<ActionResult<List<TmpParkingSpaceLoad>>> GetPercentageForParkingSpace(int Id, string datum)
        {
            return _parkingSpotService.GetPercentageForParkingSpace(Id, datum);
        }
    }
}

