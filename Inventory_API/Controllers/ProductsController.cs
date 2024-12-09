using Inventory_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]  
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        
        [HttpGet("{id}")] 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {        
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);              
        }

       
        [HttpPost] 
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            _context.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Details), new { id = product.Id }, product);
        }
        [HttpPut]
        public async Task<IActionResult> Edit (int Id , Product product)
        {
            if (Id != product.Id)
            {
                return NotFound();

            }
            var eProduct = await _context.Products.FindAsync(Id);
            if (eProduct == null)
            {
                return NotFound();
            }
            //eProduct.Name = product.Name;
            //eProduct.Description = product.Description;
            //eProduct.Price = product.Price;
            //eProduct.Image = product.Image;


            return Ok( eProduct);
        }
    }
}
