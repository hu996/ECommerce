using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class SalesBridg
    {
        public int SalesBridgId { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public decimal SalesPrice { get; set; }

        public virtual SalesInvoice Invoice { get; set; }
        public virtual Item Item { get; set; }
    }
}
