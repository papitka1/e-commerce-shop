using E_commerceShop.Data;
using E_commerceShop.Models;
using E_commerceShop.ModelsDto;
using E_commerceShop.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerceShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EshopController : ControllerBase
    {

        private readonly ShopDbContext _dbContext;
        private readonly IProductServices1 _getService;

        public EshopController(IProductServices1 getService)
        {
            _getService = getService;
        }


        // GET: api/<EshopController>
        [HttpGet]
        [Route("/GetAllPrd")]
        public ActionResult<IEnumerable<Product>> GetById()
        {
            var product = _getService.Getthis();
            return Ok(product);

        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetAll(int id)
        {
            var product = _getService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _getService.CreateProduct(dto);
            return Created($"/api/product/{id}", null);


        }


        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] EntityChangeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var IsUpdated = _getService.ChangeProductData(id, dto);
            if (!IsUpdated)
            {
                return NotFound();
            }
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _getService.DeleteProduct(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
