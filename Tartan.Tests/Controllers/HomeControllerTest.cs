#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tartan;
using Tartan.Controllers;
using Tartan.Services.Mongo;

namespace Tartan.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		public HomeControllerTest()
		{
			pageService = new PageService();
		}

		IPageService pageService;

		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController(pageService);

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			ViewDataDictionary viewData = result.ViewData;
			Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
		}

		[TestMethod]
		public void About()
		{
			// Arrange
			HomeController controller = new HomeController(pageService);

			// Act
			ViewResult result = controller.About() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
#endif