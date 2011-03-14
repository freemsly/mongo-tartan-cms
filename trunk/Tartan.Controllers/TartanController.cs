using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tartan.Models;

namespace Tartan.Controllers
{
	public class TartanController : Controller
	{
		protected ITartanService tartanService;

		public TartanController(ITartanService tartanService)
		{
			this.tartanService = tartanService;
		}

		protected override ViewResult View(IView view, object model)
		{
			return base.View(view, model);
		}

		protected override ViewResult View(string viewName, string masterName, object model)
		{
			if (!ViewData.ContainsKey("PageList"))
			{
				ViewData.Add("PageList", PageList);
			}
			return base.View(viewName, masterName, model);
		}

		protected List<PageModel> PageList
		{
			get
			{
				if (tartanService == null)
				{
					return new List<PageModel>();
				}
				else
				{
					return tartanService.PageList;
				}
			}
		}
	}
}