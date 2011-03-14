using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Controllers;
using Tartan.Models;
using System.Web.Security;

namespace Tartan.Services.Mongo
{
	public class AccountService : TartanService
	{
		public override void Load()
		{
			Bind<ILogOnModel>().To<LogOnModel>();
			Bind<IChangePasswordModel>().To<ChangePasswordModel>();
			Bind<IRegisterModel>().To<RegisterModel>();
		}
	}

	public class FormsAuthenticationService : IFormsAuthenticationService
	{
		public void SignIn(string userName, bool createPersistentCookie)
		{
			if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

			FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}
