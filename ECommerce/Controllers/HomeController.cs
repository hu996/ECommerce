using ECommerce.BL;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
	public class HomeController : Controller
	{
		private readonly IISlider _slider;
		private readonly IIitem _item;
        public HomeController(IISlider slider,IIitem item)
        {
            _slider=slider;
			_item=item;
        }

        public IActionResult Index()
		{
			ViewModel VModel=new ViewModel();
			VModel.SliderInfo = _slider.GetAll().Take(5);
			VModel.ItemInfo=_item.GetAll().Take(35);			
			return View(VModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
