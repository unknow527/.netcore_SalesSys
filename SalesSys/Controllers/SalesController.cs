using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSys.Models;

namespace SalesSys.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet]
        public List<TProduct> GetProducts()
        {
            List<TProduct> products =new List<TProduct>();

            //## Context繼承至IDisposable，使用完要釋放:
            //1. 最後輸入context.Dispose(); 釋放。
            //dbShoppingContext context = new dbShoppingContext();
            //products = context.TProducts.ToList();
            //context.Dispose();

            //2.使用using(){ }包覆，結束後自動釋放。
            using (dbShoppingContext context = new dbShoppingContext())
            {
                products = context.TProducts.ToList();
            }

            return products;


        }
    }
}
