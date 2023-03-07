using RepositoriesLibrary.Roles;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Security.Claims;

namespace WebApplication_Atlantis.Controllers
{
    [ApiController,Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("Add")]
        public IResult Add(string categoryName)
        {
            try
            {

                _unitOfWork.CategoryRep.Create(new Category() { Name = categoryName });
                _unitOfWork.Commit();
                return Results.Ok();

            }
            catch (Exception ex) { return Results.Ok(ex.Message); }

        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("Delete")]
        public IResult Delete(int id)
        {
            try
            {
                if (_unitOfWork.CategoryRep.DeleteCategory(id))

                {
                    _unitOfWork.Commit();
                    return Results.Ok();
                }
                return Results.BadRequest("Remove items from category!");

            }
            catch (Exception ex) { return Results.BadRequest(ex.Message); }

        }

        [HttpGet]
        [Route("GetCategoryById")]

        public IResult GetCategoryById(int id)
        {

            try
            {

                return Results.Ok(_unitOfWork.CategoryRep.Get(id));

            }
            catch (Exception ex) { return Results.BadRequest(ex.Message); }

        }

    

        [HttpGet]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Category>>> GettAll()
        {
            try
            {
                return _unitOfWork.CategoryRep.GetAll().ToList();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

    }
}
