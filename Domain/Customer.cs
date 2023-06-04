using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SalesInvoices = new HashSet<SalesInvoice>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Customerphone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }

        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }
    }
}
