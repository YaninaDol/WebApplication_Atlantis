using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLibrary.Models;
using RepositoriesLibrary.Interfaces;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Atlantis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public RoomController(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }


        [HttpGet]
        [Route("GetRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {

          

            List<Room> roomsCache = _cacheService.GetData<List<Room>>("Rooms");
            if (roomsCache == null)
            {
                var roomsSQL =  _unitOfWork.RoomRepository.getAllList().ToList();
                if (roomsSQL.Count > 0)
                {
                    roomsCache = roomsSQL;
                    _cacheService.SetData("Rooms", roomsSQL, DateTimeOffset.Now.AddDays(1));



                }
            }


            return roomsCache;

        }

        


    }
}

