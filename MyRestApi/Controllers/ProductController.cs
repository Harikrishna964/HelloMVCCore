using Microsoft.AspNetCore.Mvc;

using MyRestApi.Models;
 
namespace MyRestApi.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class ProductsController : ControllerBase

    {

        static readonly IProductRepository _repository = new ProductRepository(); [HttpGet]

        public IActionResult GetAllProducts()

        {

            return Ok(_repository.GetAll());

        }

        [HttpPost]

        public IActionResult Create([FromBody] Product product)

        {

            var createdProduct = _repository.Add(product); return CreatedAtRoute("GetProduct", new { id = createdProduct.Id }, createdProduct);

        }
        [HttpGet("{id}", Name = "GetProduct")]

        public IActionResult GetProduct(int id)

        {

            Product item = _repository.Get(id);

            if (item == null)

            {

                NotFound();

            }

            return Ok(item);

        }         //[HttpGet("{category}", Name = "GetProductByCategory")]

        //public IActionResult GetProductsByCategory(string category)

        //{

        //    return (IActionResult)Ok(_repository.GetAll().Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase)));

        //}

        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] Product product)

        {

            product.Id = id;

            if (!_repository.Update(product))

            {

                NotFound();

            }

            return Ok(_repository.Update(product));

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)

        {

            _repository.Remove(id);

            return NoContent();

        }
    }

}
