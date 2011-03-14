using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web;

public static class Extensions
{
	public static string UrlEncode(this string value)
	{
		return HttpUtility.UrlEncode(value);
	}

	public static string UrlDecode(this string value)
	{
		return HttpUtility.UrlDecode(value);
	}

	public static string UrlEncodeSeo(this string value)
	{
		return value.UrlEncode().Replace("+", "-");
	}

	public static string UrlDecodeSeo(this string value)
	{
		return value.Replace("-", "+").UrlDecode();
	}

	public static bool IsEditor(this IPrincipal principal)
	{
		return principal.IsInRole(Roles.Editor);
	}
}
