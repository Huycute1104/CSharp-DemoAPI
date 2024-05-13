using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SE160548.ProductManagement.API.Models;
using SE160548.ProductManagement.Repo.Models;
using SE160548.ProductManagement.Repo.UnitOfwork;

namespace SE160548.ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfwork unitOfwork;

        public ProductController(IUnitOfwork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(unitOfwork.ProductRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id) 
        {
            try
            {
                Product product = unitOfwork.ProductRepo.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateProduct(Models.CreateProductModel product) 
        {
            try
            {
                var productlast = unitOfwork.ProductRepo.GetAll().LastOrDefault();
                Product create = new Product();
                create.ProductId = productlast.ProductId +1 ;
                create.ProductName = product.ProductName;
                create.UnitPrice = product.UnitPrice;
                create.CategoryId = product.CategoryId;
                create.Weight = product.Weight;
                create.UnitsInStock = product.UnitsInStock;
                unitOfwork.ProductRepo.Add(create);
                
                return Ok(create);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]    
        public IActionResult DeleteProductById(int id) 
        {
            try
            {
                Product product = unitOfwork.ProductRepo.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                unitOfwork.ProductRepo.Delete(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateResult(int id,Models.CreateProductModel model) 
        {
            try
            {
                Product product = unitOfwork.ProductRepo.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.Weight = model.Weight;  
                product.UnitsInStock = model.UnitsInStock;
                product.ProductName = model.ProductName;
                unitOfwork.ProductRepo.Update(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
