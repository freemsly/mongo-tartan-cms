using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Models;

namespace Tartan.Controllers
{
	public interface IModuleService
	{
		PageModel GetPage(string id);

		void Save(PageModel page);
	}
}
