using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Models;

namespace Tartan.Controllers
{
	public interface ITartanService
	{
		List<PageModel> PageList{ get; }

		IFormsAuthenticationService FormsService { get; }
		IMembershipService MembershipService { get; }
	}
}
