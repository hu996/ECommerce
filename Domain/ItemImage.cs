using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Models
{
    public partial class ItemImage
    {
        public int ItemImageId { get; set; }
        public string ImageName { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
