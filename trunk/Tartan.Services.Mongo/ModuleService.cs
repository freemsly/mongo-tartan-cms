using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tartan.Controllers;
using MongoDB;
using Ninject.Modules;

namespace Tartan.Services.Mongo
{
	public abstract class ModuleService : MongoService
	{

		public Models.PageModel GetPage(string pageIDString)
		{
			return base.GetPageByID(pageIDString);
		}
	}
}