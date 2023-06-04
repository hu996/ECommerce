using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemImages = new HashSet<ItemImage>();
            SalesBridgs = new HashSet<SalesBridg>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasPrice { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public int CategoryId { get; set; }
        public string ItemImage { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ICollection<SalesBridg> SalesBridgs { get; set; }
    }
}
