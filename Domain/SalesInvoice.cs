using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class SalesInvoice
    {
        public SalesInvoice()
        {
            SalesBridgs = new HashSet<SalesBridg>();
        }

        public int InvoicId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OredrDate { get; set; }
        public DateTime Deliverydate { get; set; }
        public string Notes { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<SalesBridg> SalesBridgs { get; set; }
    }
}
