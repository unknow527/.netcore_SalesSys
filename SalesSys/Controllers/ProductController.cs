using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSys.Models;
using SQLitePCL;
using SalesSys.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace SalesSys.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly dbShoppingContext _context;
        public ProductController(dbShoppingContext context)
        {
            _context = context;
        }

        // RESTful風格寫法，Controller中的同類型方法都只能有一個，如Get、Post，透過加上路由(參數)識別。

        // Get
        [HttpGet]
        public ActionResult<IEnumerable<TProduct>> Get()
        {
            return _context.TProducts;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var result = _context.TProducts.FirstOrDefault(m => m.FId == id);
            //var result = from p in _context.TProducts where(p.FId == id) select p;
            var result = _context.TProducts.Find(id);
            if (result == null)
            {
                return NotFound("沒有資料");
            }
            return Ok(result); //回傳HTTP 200
        }
        [HttpPost]
        public ActionResult<TProduct> Post([FromBody] TProduct product)
        {
            _context.TProducts.Add(product);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(Post), new { id = product.FId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TProduct product)
        {
            if (id != product.FId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TProducts.Any(e => e.FId == id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "存取發生錯誤");
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.TProducts.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            _context.TProducts.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
