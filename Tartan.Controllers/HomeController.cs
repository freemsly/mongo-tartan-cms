using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tartan.Models;

namespace Tartan.Controllers
{
	public class HomeController : TartanController
	{
		public HomeController(IPageService pageService) : base((ITartanService)pageService) { }

		public ActionResult Index()
		{
			ViewModel.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Misc()
		{
			ViewModel.Message = "This is my other page!";
			return View();
		}


	}
}
