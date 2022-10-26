using System;
using System.Collections.Generic;

namespace SalesSys.Models
{
    public partial class TOrderDetail
    {
        public int FOrderDetailsId { get; set; }
        public int? FOrderId { get; set; }
        public string? FPid { get; set; }
        public string? FPname { get; set; }
        public int? FPrice { get; set; }
        public int? FQty { get; set; }
    }
}
