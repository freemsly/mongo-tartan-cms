using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tartan.Models;
using Tartan.Controllers;
using MongoDB;

namespace Tartan.Services.Mongo
{
	public class PageService: TartanService, IPageService
	{
		public PageModel GetPageByTitle(string title)
		{
			var page = (from item in Pages
						where item.Title.ToLower() == title.ToLower()
						select item).First();

			return page;
		}

		public List<PageModel> GetIndex()
		{
			var pageList = (from item in Pages
							orderby item.Order ascending
							select item).ToList();

			return pageList;
		}

		public PageModel GetPage(string pageIDString)
		{
			return base.GetPageByID(pageIDString);
		}

		public new void Save(PageModel page)
		{
			base.Save(page);
		}

		public override void Load()
		{
			Bind<IPageService>().To<PageService>();
		}

	}
}