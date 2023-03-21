using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace WebApplication_Atlantis.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class RoomControllerCrud : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public RoomControllerCrud(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;

        }


     
        [HttpPost]
        [Route("Add")]
     
        public IResult Add(string Name, string Picture1, string Picture2, string Picture3, int Category, int Capacity, int Status, string Description, int Side, string Size, string Notice)
        {
            _unitOfWork.RoomRepository.Create(new Room() { Name = Name, Picture1 = Picture1, Picture2 = Picture2, Picture3 = Picture3,Category=Category,Capacity=Capacity,Status=Status,Description=Description,Side=Side,Views= _unitOfWork.RoomRepository.getSide(Side), Size=Size,Notice=Notice });
            _unitOfWork.Commit();
           
            _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
            return Results.Ok();


        }
        [HttpPost]
        [Route("Delete")]

        public IResult Delete(int Id)
        {
            _unitOfWork.RoomRepository.Delete(Id);
            _unitOfWork.Commit();

            _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
            return Results.Ok();


        }

        [HttpPost]
        [Route("Update")]

        public IResult Update([FromForm] int Id, [FromForm] string Name, [FromForm] string Picture1, [FromForm] string Picture2, [FromForm] string Picture3, [FromForm] int Category, [FromForm] int Capacity, [FromForm] int Status, [FromForm] string Description, [FromForm] int Side, [FromForm] string Size, [FromForm] string Notice)
        {

            if (_unitOfWork.RoomRepository.Update(Id, new Room() { Name = Name, Picture1 = Picture1, Picture2 = Picture2, Picture3 = Picture3, Category = Category, Capacity = Capacity, Status = Status, Description = Description, Side = Side, Size = Size, Notice = Notice }))
            {
                _unitOfWork.Commit();

                _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
                return Results.Ok();
            }
            else return Results.BadRequest();


        }

        [HttpPost]
        [Route("Availability")]

        public async Task<ActionResult<IEnumerable<Room>>> Availability([FromForm] string Start, [FromForm] string End, [FromForm] int Adults, [FromForm] int Children)
        {
            string[] str= Start.ToString().Split('-');

            DateTime startday = new DateTime(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
            string[] str2 = End.ToString().Split('-');

            DateTime endday = new DateTime(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]), Convert.ToInt32(str2[2]));

            return _unitOfWork.RoomRepository.Availability(startday, endday, Adults, Children).ToList();

        }

        [HttpPost]
        [Route("Book")]

        public IResult Book([FromForm] int roomNumber, [FromForm] string Userid, [FromForm] DateTime Start, [FromForm] DateTime End, [FromForm] string phoneNumber, [FromForm] string notice)
        {

            if (_unitOfWork.RoomRepository.booking(roomNumber, Userid, Start, End, phoneNumber, notice))
            {
                _unitOfWork.Commit();
                return Results.Ok();
            }
            else return Results.BadRequest();

        }



    }
}

