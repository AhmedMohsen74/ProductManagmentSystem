using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsMS.Models.Domain;
using ProductsMS.Models.DTOs;
using ProductsMS.Repositories.Abstract;

namespace ProductsMS.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepo;
        private readonly ICategoryRepository _CategoryRepo;

        public ProductController(IProductRepository ProductRepo , ICategoryRepository CategoryRepo)
        {
            _ProductRepo = ProductRepo;
            _CategoryRepo = CategoryRepo;
        }

        [HttpGet]
        public IActionResult GetAll(string name = "")
        {
            var data = _ProductRepo.GetAll(name);
            return Ok(data);
        }

        [HttpGet("{id}")] //api/Product/getbyid/1
        public IActionResult GetById(int id)
        {
            var product = _ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound(new
                {
                    StatusCode = 0,
                    Message = "Product not found!"
                });
            }
            product.CategoryName = _CategoryRepo.GetById(product.CategoryId)?.Name;
            return Ok(new
            {
                StatusCode = 1,
                Message = "Product Found!",
                Data = product
            });
        }

        [HttpPost]
        public IActionResult AddUpdate(Product model)
        {
            var status = new Status();

            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Error occurred. Validation failed.";
                return BadRequest(status);
            }

            if (_CategoryRepo.GetById(model.CategoryId) == null)
            {
                return BadRequest(new
                {
                    StatusCode = 0,
                    Message = "Category does not exist"
                });
            }

            if (model.Id == 0)
            {
                model.CreatedDate = DateTime.Now;  
            }
            else
            {
          
                model.CreatedDate = model.CreatedDate; 
            }

            var productsResult = _ProductRepo.AddUpdate(model);
            status.StatusCode = productsResult ? 1 : 0;
            status.Message = productsResult ? "Saved Successfully" : "Error occurred";

            return Ok(status);
        }



        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _CategoryRepo.GetAll();
            return Ok(categories);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ResultCategories = _ProductRepo.Delete(id);
            var status = new Status
            {
                StatusCode = ResultCategories ? 1 : 0,
                Message = ResultCategories ? "Deleted Successfully" : "Error occured"
            };
            return Ok(status);
        }
    }
}
