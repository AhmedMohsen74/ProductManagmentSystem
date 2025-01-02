using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsMS.Models.Domain;
using ProductsMS.Models.DTOs;
using ProductsMS.Repositories.Abstract;

namespace ProductsMS.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult GetAll(string name = "")
        {
            var data = _categoryRepo.GetAll(name);
            return Ok(data);
        }

        [HttpGet("{id}")] //api/category/getbyid/1
        public IActionResult GetById(int id)
        {
            var status = new Status();

            var Categories = _categoryRepo.GetById(id);
            if (Categories == null)
            {
                return NotFound(new
                {
                    StatusCode = 0,
                    Message = "Category not found!"
                });
            }

            return Ok(new
            {
                StatusCode = 1,
                Message = "Category Found!",
                Data = Categories
            });
        }

        [HttpPost]
        public IActionResult AddUpdate(Category Model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Error occured Validation Failed";
            }
            var ProductsResult = _categoryRepo.AddUpdate(Model);
            status.StatusCode = ProductsResult ? 1 : 0;
            status.Message = ProductsResult ? "Saved Successfully" : "Error occured";
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ResultCategories = _categoryRepo.Delete(id);
            var status = new Status
            {
                StatusCode = ResultCategories ? 1 : 0,
                Message = ResultCategories ? "Deleted Successfully" : "Error occured"
            };
            return Ok(status);
        }
    }
}
