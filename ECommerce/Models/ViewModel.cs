using System.Collections.Generic;

namespace ECommerce.Models
{
    public class ViewModel
    {
        public IEnumerable<Slider> SliderInfo { get; set; }
        public IEnumerable<Item> ItemInfo { get; set; }

    }
}
