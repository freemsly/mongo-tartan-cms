using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Controllers;
using Tartan.Models;
using MongoDB;

namespace Tartan.Services.Mongo
{
	public class TartanService : MongoService, ITartanService
	{
		public List<PageModel> PageList
		{
			get
			{
				return pageList.Value;
			}
		}
		private Lazy<List<PageModel>> pageList = new Lazy<List<PageModel>>(()=>{
			return Data.GetDB().GetDatabase("tartan").GetCollection<PageModel>("pages").Linq().OrderBy(p => p.Order).ToList();			
		});


		public override void Load()
		{
			Bind<ITartanService>().To<TartanService>();
		}


		public IFormsAuthenticationService FormsService
		{
			get
			{
				return formsService.Value;
			}
		}
		private Lazy<IFormsAuthenticationService> formsService = new Lazy<IFormsAuthenticationService>(
			() => {
				return new FormsAuthenticationService();
			});

		public IMembershipService MembershipService
		{
			get
			{
				return membershipService.Value;
			}
		}

		private Lazy<IMembershipService> membershipService = new Lazy<IMembershipService>(
			() => {
				return new AccountMembershipService();
			});
	}
}
