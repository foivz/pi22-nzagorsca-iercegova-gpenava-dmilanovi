﻿using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ParkingSpaceService _parkingSpaceService;
        private readonly ParkingSessionService _parkingSessionService;
        private readonly ParkingSpotService _parkingSpotService;
        private readonly ParkingUsersService _parkingUserService;
        private readonly ParkingSensorService _parkingSensorService;
        public LoginController(ParkingSpaceService parkingSpaceService, ParkingUsersService parkingUserService, ParkingSessionService parkingSessionService, ParkingSpotService parkingSpotService, ParkingSensorService parkingSensorService)
        {
            _parkingSpaceService = parkingSpaceService;
            _parkingSessionService = parkingSessionService;
            _parkingSpotService = parkingSpotService;
            _parkingUserService = parkingUserService;
            _parkingSensorService = parkingSensorService;
        }

        [HttpGet]
        [Route("specificUser")]
        public async Task<ActionResult<List<TmpUser>>> GetSpecificUser(int user_Id, string lozinka)
        {
            return _parkingUserService.GetSpecificUser(user_Id, lozinka);
        }

        [HttpGet]
        [Route("allUsers")]
        public async Task<ActionResult<List<TmpUser>>> GetUsers()
        {
            return _parkingUserService.GetAllParkingUsers();
        }


        [HttpPost]
        [Route("addUser")]
        public async void AddNewUser(string ime, string prezime, string username, string lozinka, string tablicaAutomobila)
        {
            _parkingUserService.AddNewUser(ime, prezime, username, lozinka, tablicaAutomobila);
            GetUsers();
        }
    }
}
