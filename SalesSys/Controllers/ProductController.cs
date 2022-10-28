using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSys.Models;
using SQLitePCL;
using SalesSys.ViewModels;
using Newtonsoft.Json;

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

        [HttpGet]
        public List<TProduct> Get()
        {
            //會造成循環引用，要透過後續方法解決
            var products = new ProductViewModel(_context).GetProducts();

            return products;

        }
    }
}
