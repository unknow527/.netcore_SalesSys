using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalesSys.Models;
using SQLitePCL;

namespace SalesSys.ViewModels
{
    public class ProductViewModel
    {
        //ef core 領域模型(充血模型) =>>同時包含[屬性]及[方法]

        //內部成員變數
        public readonly dbShoppingContext _context;
        //[屬性] table欄位 from TProduct.cs
        public int FId { get; set; }
        public int? FCategoryId { get; set; }
        public string? FPid { get; set; }
        public string? FPname { get; set; }
        public int? FPrice { get; set; }
        public string? FImg { get; set; }


        //在構造函數中實例化
        public ProductViewModel(dbShoppingContext context)
        {
            _context = context;
        }
        //[方法]
        public List<TProduct> GetProducts()
        {
            var products = _context.TProducts.ToList();
            //方案1 反序列化(不推薦) - JsonSerializerSetting (要安裝NuGet newtonsoft.json)
            //JsonSerializerSettings setting = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Formatting = Formatting.None,
            //};
            //var json = JsonConvert.SerializeObject(products, setting);

            //方案2 

            return products;
        }
    }
}
