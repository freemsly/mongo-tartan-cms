using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Mvc;
using Ninject;
using System.Reflection;

namespace Tartan
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : NinjectHttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Home", // Route name
				"", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

			routes.MapRoute("Pages",
				"{title}",
				new { controller = "Page", action = "Details", title = UrlParameter.Optional }
			);

			routes.MapRoute("Page Edit",
				"{title}/Edit",
				new { controller = "Page", action = "Edit", title = UrlParameter.Optional }
			);

			routes.MapRoute("Page Edit Module",
				"{pageTitle}/Edit/{moduleTitle}",
				new { controller = "Page", action = "EditModule", pageTitle = UrlParameter.Optional, moduleTitle = UrlParameter.Optional }
			);

			routes.MapRoute("Page Add Module",
				"{pageTitle}/Add",
				new { controller = "Page", action = "AddModule", pageTitle = UrlParameter.Optional }
			);

			routes.MapRoute("Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected override void OnApplicationStarted()
		{
			base.OnApplicationStarted();

			AreaRegistration.RegisterAllAreas();
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}


		protected override Ninject.IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			kernel.Load(new List<String>() { "Tartan.Services.*" });
			return kernel;
		}
	}
}