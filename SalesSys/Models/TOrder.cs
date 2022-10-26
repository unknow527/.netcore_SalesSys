using System;
using System.Collections.Generic;

namespace SalesSys.Models
{
    public partial class TOrder
    {
        public int FOrderId { get; set; }
        public string? FUid { get; set; }
        public string? FReceiver { get; set; }
        public string? FReceiverPhone { get; set; }
        public string? FReceiverAddress { get; set; }
        public DateTime? FOrderDate { get; set; }
        public string? FOrderState { get; set; }
    }
}
