using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSys.Models;
using SQLitePCL;

namespace SalesSys.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // **實例化-------------------------------------------------------------------------
        // 1. 宣告私有的全域變數
        private readonly dbShoppingContext _dbShoppingContext;
        // 2. 建構函數，接收實例
        public SalesController(dbShoppingContext dbShoppingcontext)
        {
            _dbShoppingContext = dbShoppingcontext;

            //全局取消追蹤機制
            //dbShoppingcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        // -------------------------------------------------------------------------------

        [HttpGet]
        public TProduct GetProducts()
        {
            //局部取消追蹤機制，提高效能
            IQueryable<TProduct> products = _dbShoppingContext.TProducts.AsNoTracking();
            //查詢時不會追蹤
            var product = products.Single(m => m.FId == 35);
            product.FPname = "test";

            _dbShoppingContext.Update(product); //追蹤機制啟動時，沒update也能更新資料庫
            _dbShoppingContext.SaveChanges();

            return product;
        }

        [HttpGet]
        public List<TOrder> GetOrders()
        {
            //List<TOrder> orders = _dbShoppingContext.TOrders.ToList();
            List<TOrder> orders = _dbShoppingContext.TOrders.ToList();

            return orders;
        }
    }
}
