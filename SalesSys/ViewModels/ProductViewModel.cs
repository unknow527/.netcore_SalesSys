using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalesSys.Models;
using SQLitePCL;

namespace SalesSys.ViewModels
{
    public class ProductViewModel
    {

        public int FId { get; set; }
        public int? FCategoryId { get; set; }
        public string? FPid { get; set; }
        public string? FPname { get; set; }
        public int? FPrice { get; set; }
        public string? FImg { get; set; }

    }
}
