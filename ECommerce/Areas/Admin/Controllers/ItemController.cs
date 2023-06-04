using ECommerce.BL;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly IIitem _item;
        private readonly IICategory _category;
        public ItemController(IIitem item,IICategory category)
        {
            _item = item;
            _category = category;
        }
        public IActionResult List()
        {
            return View(_item.GetAll());
        }
        public IActionResult Edit()
        {
            ViewBag.Category = _category.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Save(Item item,List<IFormFile>files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string ItemImage = Guid.NewGuid() + ".jpg";
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", ItemImage);
                    using (var stream = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(stream);
                    }
                    item.ItemImage = ItemImage;
                }
            }
            _item.Save(item);
            return RedirectToAction("List");
        }
        public IActionResult Update(int? ItemID) 
        {
            return View(_item.GetById(Convert.ToInt32(ItemID)));
        }
        [HttpPost]
        public IActionResult Update(Item item)
        {
            _item.Edit(item);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? ItemId)
        {
            _item.Delete(Convert.ToInt32(ItemId));
            return RedirectToAction("List");
        }
    }
}
