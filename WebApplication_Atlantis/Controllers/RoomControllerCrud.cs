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

        public RoomControllerCrud(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


     
        [HttpPost]
        [Route("Add")]

        public IResult Add()
        {
            //_context.Add(new Product() { Name = Name, Price = price, Image = image, CategoryId = categoryId });

            //_context.SaveChanges();
            //_cacheService.SetData("Product", _context.Products.ToList(), DateTimeOffset.Now.AddDays(1));
            return Results.Ok();


        }


    }
}

