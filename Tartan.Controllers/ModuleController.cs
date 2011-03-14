using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Permissions;
using Tartan.Models;

namespace Tartan.Controllers
{
    public class ModuleController : Controller
    {
		public ActionResult Edit(PageModel page, string moduleTitle, FormCollection collection)
		{
			try
			{
				var oldTitle = (from y in collection.AllKeys
								where y.StartsWith("frm_title_")
								select y.Replace("frm_title_", String.Empty).UrlDecodeSeo()).FirstOrDefault();

				if (!String.IsNullOrEmpty(oldTitle))
				{
					var module = (from m in page.Modules
								  where m.Title == oldTitle
								  select m).FirstOrDefault();

					if (module is ContentModule)
					{
						UpdateModule((ContentModule)module, collection);
					}
					else if (module is ListModule)
					{
						UpdateModule((ListModule)module, collection);
					}
					else if (module == null)
					{
						return Json(new { status = "fail", message = "Module " + oldTitle + " not found." });
					}

					return Json(new { status = "success", module = module.Title });
				}

				return Json(new { status = "success", message = "No Module Updated" });
			}
			catch
			{
				return Json(new { status = "fail" }); ;
			}
		}
/*
		public ActionResult Add(PageModel page, Type moduleType, string moduleTitle, FormCollection collection)
		{
			if (moduleType == ContentModule)
			{
				var newModule = new ContentModule();

				UpdateModel<ContentModule>(newModule, 
			}
		}
		*/
		private void UpdateModule(ContentModule module, FormCollection collection)
		{
			module.Content = (from y in collection.AllKeys
							  where y.StartsWith("frm_content")
							  select collection[y]).FirstOrDefault();

			module.Title = (from y in collection.AllKeys
							where y.StartsWith("frm_title")
							select collection[y]).FirstOrDefault();
		}

		private void UpdateModule(ListModule module, FormCollection collection)
		{
			var listOfKeys = (from y in collection.AllKeys
							  where y.StartsWith("frm_list_key_")
							  select y);

			foreach (string formKey in listOfKeys)
			{
				string key = formKey.Replace("frm_list_key_", String.Empty).UrlDecodeSeo();
				string valueFormKey = formKey.Replace("frm_list_key", "frm_list_value");
				string value = collection[valueFormKey];
				bool isExistingField = !key.EndsWith("newField");

				if (!isExistingField)
				{
					key = collection[formKey];
				}

				if (!String.IsNullOrEmpty(key) && !module.ListItems.ContainsKey(key))
				{
					module.ListItems.Add(key, collection[valueFormKey]);
				}
				else if (isExistingField || !String.IsNullOrEmpty(value))
				{

					if (value == "{delete}")
					{
						module.ListItems.Remove(key);
					}
					else
					{
						module.ListItems[key] = value;
					}
				}
			}

		}
    }
}
