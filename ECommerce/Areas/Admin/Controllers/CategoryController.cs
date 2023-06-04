using ECommerce.BL;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerceD.Area.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly IICategory _category;
		public CategoryController(IICategory category)
		{
			_category=category;
		}
		public IActionResult MyCategory()
		{
			return View(_category.GetAll());
		}
        public IActionResult Edit()
        {
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult Save(Category category)
        {
			if (ModelState.IsValid)
			{
				if (category.CategoryId == 0 || category.CategoryId == null)
				{
                    _category.Create(category);
                    return RedirectToAction("MyCategory");
                }
				else
				{
					_category.Edit(category);
					return RedirectToAction("MyCategory");
				}
				
			}
			else
			{
				return View(category);
			}
           
        }
		public IActionResult Update(int? CategoryId)
		{
			if(CategoryId!=null)
			{
				return View(_category.GetById(Convert.ToInt32(CategoryId)));
			}
			else
			{
				return View();
			}
			
		}
		public IActionResult Delete(int? CategoryId)
		{
			_category.Delete(Convert.ToInt32(CategoryId));
			return RedirectToAction("MyCategory");
		}
    }
}
