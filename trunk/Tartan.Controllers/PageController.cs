using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tartan.Models;
using System.Collections.Specialized;
using System.Security.Permissions;

namespace Tartan.Controllers
{
    public class PageController : TartanController
    {
		private IPageService pageService;

		public PageController(IPageService pageService) : base((ITartanService)pageService)
		{
			this.pageService = pageService;
		}

		public ActionResult Index()
		{
			var pageList = pageService.GetIndex();

			return View(pageList);
		}

        public ActionResult Details(string title)
        {
			if (title == null)
			{
				return View();
			}

			title = title.UrlDecodeSeo();

			var page = pageService.GetPageByTitle(title);

			return View(page);
        }

        //
        // GET: /Page/Create
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Page/Create

        [HttpPost]
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Page/Edit/5

		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult Edit(string title)
        {
            return Details(title);
        }

        //
        // POST: /Page/Edit/5

        [HttpPost]
		[PrincipalPermission(SecurityAction.Demand, Role=Roles.Editor)]
        public ActionResult Edit(string title, FormCollection collection)
        {
            try
            {
				var page = pageService.GetPageByTitle(title.UrlDecodeSeo());

				UpdateModel(page);

				if (ModelState.IsValid)
				{
					pageService.Save(page);
				}
            }
            catch(Exception exc)
            {
				return Json(new { status = "fail" }); ;
            }

			return Json(new { status = "success" });
        }

		[HttpPost]
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult EditModule(string pageTitle, string moduleTitle, FormCollection collection)
		{
			try
			{
				var page = pageService.GetPageByTitle(pageTitle.UrlDecodeSeo());

				ModuleController mc = new ModuleController();

				var editResult = mc.Edit(page, moduleTitle.UrlDecodeSeo(), collection);

				pageService.Save(page);

				return editResult;
			}
			catch
			{
				return Json(new { status = "fail", message = "Unable to save page " + pageTitle.UrlDecodeSeo() }); ;
			}
		}

		[HttpPost]
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult AddModule(string pageTitle, FormCollection collection)
		{
			throw new NotImplementedException();
			var page = pageService.GetPageByTitle(pageTitle.UrlDecodeSeo());

			ModuleController mc = new ModuleController();

//			mc.Edit
		}


        //
        // GET: /Page/Delete/5
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Page/Delete/5

        [HttpPost]
		[PrincipalPermission(SecurityAction.Demand, Role = Roles.Editor)]
		public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
