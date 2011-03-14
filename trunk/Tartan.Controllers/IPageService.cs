using System;
using Tartan.Models;
using System.Collections.Generic;

namespace Tartan.Controllers
{
	public interface IPageService
	{
		PageModel GetPage(string pageIDString);
		PageModel GetPageByTitle(string title);
		List<PageModel> GetIndex();
		void Save(PageModel page);
	}
}
