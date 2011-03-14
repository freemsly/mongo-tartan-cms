using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Controllers;
using Tartan.Models;

namespace Tartan.Services.Mongo
{
	public class AccountService
	{
		public override void Load()
		{
			Bind<ILogOnModel>().To<LogOnModel>();
			Bind<IChangePasswordModel>().To<ChangePasswordModel>();
			Bind<IRegisterModel>().To<RegisterModel>();
		}
	}
}
