using System;
using System.Collections.Generic;

namespace SalesSys.Models
{
    public partial class TShoppingCar
    {
        public int FId { get; set; }
        public string? FUid { get; set; }
        public string? FPid { get; set; }
        public string? FPname { get; set; }
        public int? FPrice { get; set; }
        public int? FQty { get; set; }
    }
}
