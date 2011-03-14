using System;
using Tartan.Controllers;

namespace Tartan.Models
{
	public class LogOnModel : ILogOnModel
	{
		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public bool RememberMe
		{
			get;
			set;
		}
	}

	public class ChangePasswordModel : IChangePasswordModel
	{
		public string OldPassword
		{
			get;
			set;
		}

		public string NewPassword
		{
			get;
			set;
		}

		public string ConfirmPassword
		{
			get;
			set;
		}
	}

	public class RegisterModel : IRegisterModel
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
	}

}
