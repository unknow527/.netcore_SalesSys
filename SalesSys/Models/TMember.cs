using System;
using System.Collections.Generic;

namespace SalesSys.Models
{
    public partial class TMember
    {
        public string FUid { get; set; } = null!;
        public string? FPwd { get; set; }
        public string? FName { get; set; }
        public string? FEmail { get; set; }
    }
}
