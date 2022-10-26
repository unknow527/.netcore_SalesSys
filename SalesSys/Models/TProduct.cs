using System;
using System.Collections.Generic;

namespace SalesSys.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        public int? FCategoryId { get; set; }
        public string? FPid { get; set; }
        public string? FPname { get; set; }
        public int? FPrice { get; set; }
        public string? FImg { get; set; }
    }
}
