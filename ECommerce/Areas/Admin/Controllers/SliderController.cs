using Microsoft.AspNetCore.Mvc;
using ECommerce.BL;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.IO;

namespace ECommerce.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly IISlider _slider;
		public SliderController(IISlider slider)
		{
			_slider = slider;
		}
		public IActionResult MySlider()
		{
			
			return View(_slider.GetAll());
		}
		public IActionResult Edit()
		{ 
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Slider slider, List<IFormFile> Files)
		{
			if (ModelState.IsValid)
			{
				foreach (var file in Files)
				{
					if (file.Length > 0)
					{
						string SliderImage = Guid.NewGuid().ToString() + ".jpg";
						var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", SliderImage);
						using (var stream = System.IO.File.Create(filepath))
						{
							file.CopyTo(stream);
						}
						slider.SliderImage = SliderImage;
					}
				}
				
				if (slider.SliderId == 0 || slider.SliderId == null)
				{
                    _slider.Create(slider);
                    return RedirectToAction("MySlider");
                }
				else
				{
					_slider.Update(slider);
                    return RedirectToAction("MySlider");
                }
            }
			else
			{
				return View(slider);
			}

			
		}
		public IActionResult Update(int? sliderid)
		{
			
			return View(_slider.GetById(Convert.ToInt32(sliderid)));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Slider slider)
		{
			if (slider.SliderId !=null)
			{
             
			  return View(_slider.Update(slider));
			}
			else
			{
				return View();
			}
			
		}
		
		public IActionResult Delete(int?sliderid)
		{
			
			_slider.Delete(sliderid);
			return RedirectToAction("MySlider");
		}
	}
}
