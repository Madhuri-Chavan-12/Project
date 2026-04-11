using Microsoft.AspNetCore.Mvc;
using DevOpsApp.Data;
using DevOpsApp.Models;

namespace DevOpsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL PRODUCTS
        // GET: /api/Product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // ✅ GET PRODUCT BY ID
        // GET: /api/Product/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        // ✅ CREATE PRODUCT
        // POST: /api/Product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        // ✅ UPDATE PRODUCT
        // PUT: /api/Product/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound("Product not found");

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            _context.SaveChanges();

            return Ok(product);
        }

        // ✅ DELETE PRODUCT
        // DELETE: /api/Product/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound("Product not found");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok("Product deleted successfully");
        }
    }
}