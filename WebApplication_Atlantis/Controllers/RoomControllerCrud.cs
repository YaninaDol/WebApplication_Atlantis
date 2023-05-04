using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using RepositoriesLibrary.Roles;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace WebApplication_Atlantis.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class RoomControllerCrud : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ICacheService _cacheService;

        public RoomControllerCrud(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          //  _cacheService = cacheService;

        }


     
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("Add")]
     
        public IResult Add([FromForm] string Name, [FromForm] string Picture1, [FromForm] string Picture2, [FromForm] string Picture3, [FromForm] int Category, [FromForm] int Capacity, [FromForm] string Description, [FromForm] int Side, [FromForm] string Size, [FromForm] string Notice)
        {
            _unitOfWork.RoomRepository.Create(new Room() { Name = Name, Picture1 = Picture1, Picture2 = Picture2, Picture3 = Picture3,Category=Category,Capacity=Capacity,Status=1,Description=Description,Side=Side,Views= _unitOfWork.RoomRepository.getSide(Side), Size=Size,Notice=Notice });
            _unitOfWork.Commit();
           
          //  _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
            return Results.Ok();


        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("Delete")]

        public IResult Delete([FromForm] int Id)
        {
            _unitOfWork.RoomRepository.Delete(Id);
            _unitOfWork.Commit();

          //  _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
            return Results.Ok();


        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("Update")]

        public IResult Update([FromForm] int Id, [FromForm] string Name, [FromForm] string Picture1, [FromForm] string Picture2, [FromForm] string Picture3, [FromForm] int Category, [FromForm] int Capacity, [FromForm] string Description, [FromForm] int Side, [FromForm] string Size, [FromForm] string Notice)
        {

            if (_unitOfWork.RoomRepository.Update(Id, new Room() { Name = Name, Picture1 = Picture1, Picture2 = Picture2, Picture3 = Picture3, Category = Category, Capacity = Capacity, Status = 1, Description = Description, Side = Side, Size = Size, Notice = Notice }))
            {
                _unitOfWork.Commit();

              //  _cacheService.SetData("Rooms", _unitOfWork.RoomRepository.GetAll(), DateTimeOffset.Now.AddDays(1));
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

        public IResult Book([FromForm] int roomNumber, [FromForm] string Userid, [FromForm] string FirstName, [FromForm] int totaldays, [FromForm] string LastName, [FromForm] string Start, [FromForm] string End, [FromForm] string phoneNumber, [FromForm] string notice)
        {

            string[] str = Start.ToString().Split('-');

            DateTime startday = new DateTime(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
            string[] str2 = End.ToString().Split('-');

            DateTime endday = new DateTime(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]), Convert.ToInt32(str2[2]));


            if (_unitOfWork.RoomRepository.booking(roomNumber, Userid, FirstName, totaldays, LastName, startday, endday, phoneNumber, notice))
            {
                _unitOfWork.Commit();
                return Results.Ok();
            }
            else return Results.BadRequest();

        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("CloseStatus")]

        public IResult CloseStatus([FromForm] int Id)
        {
            if (_unitOfWork.RoomRepository.closeStatus(Id) == true)
            {
                _unitOfWork.Commit();
                return Results.Ok();
            }
            return Results.BadRequest();


        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("PaidStatus")]

        public IResult PaidStatus([FromForm] int Id)
        {
            if (_unitOfWork.RoomRepository.paidStatus(Id) == true)
            {
                _unitOfWork.Commit();
                return Results.Ok();
            }
            return Results.BadRequest();


        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetHistory")]

        public async Task<ActionResult<IEnumerable<BookingInfo>>> GetHistory()
        {
            if (_unitOfWork.RoomRepository.getHistory().ToList().Count>0)
            {
                _unitOfWork.Commit();
                return _unitOfWork.RoomRepository.getHistory().ToList();
            }
            return null;


        }

    }
}

