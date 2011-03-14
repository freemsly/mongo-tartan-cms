using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tartan.Models;
using MongoDB;
using Ninject.Modules;

namespace Tartan.Services.Mongo
{
	public abstract class MongoService : NinjectModule
	{
		private IQueryable<ServicePageModel> ServicePages
		{
			get
			{
				return PageCollection.Linq();
			}
		}

		protected IQueryable<PageModel> Pages
		{
			get
			{
				return ServicePages;
			}
		}

		protected IMongoCollection<ServicePageModel> PageCollection
		{
			get
			{
				return DataContext.GetCollection<ServicePageModel>("pages");
			}
		}

		private IMongoDatabase _dataContext;
		public IMongoDatabase DataContext
		{
			get
			{
				if (_dataContext == null)
				{
					_dataContext = Data.GetDB().GetDatabase("tartan");
				}
				return _dataContext;
			}
		}

		public PageModel GetPageByID(string pageIDString)
		{
			Oid pageID = new Oid(pageIDString);

			var page = (from p in ServicePages
					where p.Id == pageID
					select p).FirstOrDefault();

			page.ID = pageIDString;

			return page;
		}

		public void Save(Models.PageModel page)
		{
			PageCollection.Save(page);
		}
	}
}