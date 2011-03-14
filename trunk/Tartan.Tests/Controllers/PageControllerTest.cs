#if DEBUG
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tartan.Controllers;
using Tartan.Models;
using System.Web.Mvc;
using MongoDB;
using System.Collections.Specialized;
using Tartan.Services;
using Tartan.Services.Mongo;
using System.Security.Principal;
using System.Threading;
using System.Web.Routing;
using Rhino.Mocks;
using System.Web;

namespace Tartan.Tests.Controllers
{
	[TestClass]
	public class PageControllerTest
	{
		[TestMethod]
		public void HackerTest()
		{
			string script = @"\>script type='text/javascript'>Hello World</text>";
			string encoded = System.Web.HttpUtility.UrlEncode(script);
		}

		private IPrincipal EditorPrincipal = new GenericPrincipal(new GenericIdentity("administrator"), new[] {Roles.Editor});

		public PageControllerTest()
		{
			pageService = new PageService();
		}

		IPageService pageService;

		/*		[TestMethod]
				public void IndexTest()
				{
					PageController controller = new PageController();

					controller.Index();
				}
				*/
		[TestMethod]
		public void DetailsTest()
		{
			PageController controller = new PageController(pageService);

			var result = controller.Details("About-Us") as ViewResult;

			var page = result.View;
		}

		[TestMethod]
		public void SetupData()
		{
			var db = Tartan.Services.Mongo.Data.GetDB().GetDatabase("tartan");

			var pages = db.GetCollection<PageModel>("pages");

			pages.Remove(new Document());

			pages.Save(new PageModel
			{
				Title = "Contact Us",
				Order = 100,
				Modules = new List<Module> { 
					new ContentModule { Title="Gettysburg Address", Content = "Four score and seven years ago...", Order = 100},
					new ContentModule{ Title="Jon's Job Description", Content = "I also rock!", Order = 101}}
			});

			pages.Save(new PageModel
			{
				Title = "About Us",
				Order = 101,
				Modules = new List<Module> { 
					new ListModule()
					{
						Title = "Board Members",
						ListItems = new Dictionary<string, string>() { 
							{ "Jon Lind", "303-697-3611" },
							{ "George Kacher", "999-989-9343" }
						}, 
						Order = 100
					},
					new ContentModule(){ Content = "This content lives with a a List Module.", Title="Content Module", Order=102}
				}
			});
		}

		[TestMethod]
		public void SubTypeDeserializationTest()
		{
			string title = "About Us";

			using (Mongo mongo = Tartan.Services.Mongo.Data.GetDB())
			{
				var db = mongo.GetDatabase("tartan");

				var page = (from item in db.GetCollection<PageModel>("pages").Linq()
							where item.Title.ToLower() == title.ToLower()
							select item).FirstOrDefault();

				Assert.IsTrue(page != null);
				Assert.IsTrue(page.Modules.Count > 0);
				Assert.IsTrue(page.Modules[0].GetType() == typeof(ListModule));
				Assert.IsFalse(String.IsNullOrEmpty(page.ID));

			}
		}

		[TestMethod]
		public void IndexTest()
		{
			PageController pc = new PageController(pageService);
			var result = pc.Index() as ViewResult;

			var model = result.ViewData.Model;

			Assert.IsTrue(model is List<PageModel>, "PageController.Index should return a List of PageModels");
		}

		[TestMethod]
		public void GetModulesOfDifferentTypesTest()
		{
			var db = Tartan.Services.Mongo.Data.GetDB().GetDatabase("tartan");
			var modules = (from p in db.GetCollection<PageModel>("pages").Linq()
						 where p.Title == "About Us"
						 select p.Modules).FirstOrDefault();

			Assert.IsInstanceOfType(modules[0], typeof(ListModule));

			Assert.IsInstanceOfType(modules[1], typeof(ContentModule));

		}

		[TestMethod]
		public void GetModuleIDsTest()
		{
		}

		[TestMethod]
		public void UpdateTest()
		{
			Thread.CurrentPrincipal = EditorPrincipal;

			var routeData = new RouteData();
			var httpContext = MockRepository.GenerateStub<HttpContextBase>();
			FormCollection formParameters = new FormCollection();

			PageController pc = new PageController(pageService);

			FormCollection fc = new FormCollection() { 
				{"Title","Contact Us 2"},
				{"Order","100"}
			};

			ControllerContext controllerContext =
				MockRepository.GenerateStub<ControllerContext>(httpContext,
																routeData,
																pc);

			pc.ControllerContext = controllerContext;
			pc.ValueProvider = fc.ToValueProvider();

			var ar = pc.Edit("Contact-Us", fc);
		}

		[TestMethod]
		public void UpdateListTest()
		{
			PageController pc = new PageController(pageService);

			FormCollection fc = new FormCollection() {
				{"pageID", "4d408ca4c946000000006641"},
				{"frm_list_key_Jon-Lind", "Jon Lind 2"},
				{"frm_list_value_Jon-Lind", "720-530-1172" }
			};

			var ar = pc.Edit("Board Members", fc);
		}

/*		[TestMethod]
		public void GetPageIDTest()
		{
			var db = Tartan.Helpers.Data.GetDB().GetDatabase("tartan");

			var pages = db.GetCollection<PageModel>("pages").Linq().FirstOrDefault();

			Assert.IsTrue(
		}*/
	}
}
#endif