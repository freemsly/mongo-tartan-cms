using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tartan.Controllers
{
	#region Models

	public interface IChangePasswordModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Current password")]
		string OldPassword { get; set; }

		[Required]
		[ValidatePasswordLength]
		[DataType(DataType.Password)]
		[Display(Name = "New password")]
		string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm new password")]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		string ConfirmPassword { get; set; }
	}

	public interface ILogOnModel
	{
		[Required]
		[Display(Name = "User name")]
		string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		string Password { get; set; }

		[Display(Name = "Remember me?")]
		bool RememberMe { get; set; }
	}


	public interface IRegisterModel
	{
		[Required]
		[Display(Name = "User name")]
		string UserName { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email address")]
		string Email { get; set; }

		[Required]
		[ValidatePasswordLength]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		string ConfirmPassword { get; set; }
	}
	#endregion
}
