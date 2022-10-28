using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSys.Models;

namespace SalesSys.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // **實例化 構造函數(建構子)--------------------------------------------------------
        // 1. 宣告私有的全域變數
        private readonly dbShoppingContext _dbShoppingContext;
        // 2. 建構函數，接收實例
        public TestController(dbShoppingContext dbShoppingcontext)
        {
            _dbShoppingContext = dbShoppingcontext;
        }
        // -------------------------------------------------------------------------------


        // http://localhost:51485/api/Test/GetProducts
        [HttpGet]
        public List<TProduct> GetProducts()
        {
            List<TProduct> products = new List<TProduct>();

            //## Context繼承至IDisposable，使用完要釋放:
            //1. 最後輸入context.Dispose(); 釋放。
            //dbShoppingContext dbShoppingcontext = new dbShoppingContext();
            //products = dbShoppingcontext.TProducts.ToList();
            //dbShoppingcontext.Dispose();

            //2. 使用using(){ }包覆，結束後自動釋放。
            using (dbShoppingContext context = new dbShoppingContext())
            {
                products = context.TProducts.ToList();
            }


            //3. 靜態化處理(先在容器中實例化)
            //products = _dbShoppingContext.TProducts.ToList(); 

            return products;


        }
    }
}
