using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Collections;
using Tartan.Models;

public static class Common
{
	public static string GetUIStateCss(this PageModel page)
	{
		if (HttpContext.Current.Request.Url.LocalPath.Contains(page.UriTitle))
		{
			return "ui-state-active";
		}
		else
		{
			return String.Empty;
		}
	}

	public static string GetUIStateCss()
	{
		if (HttpContext.Current.Request.Url.LocalPath == "/")
		{
			return "ui-state-active";
		}
		else
		{
			return String.Empty;
		}
	}

	/// <summary>
	/// Returns a site relative HTTP path from a partial path starting out with a ~.
	/// Same syntax that ASP.Net internally supports but this method can be used
	/// outside of the Page framework.
	/// 
	/// Works like Control.ResolveUrl including support for ~ syntax
	/// but returns an absolute URL.
	/// </summary>
	/// <param name="originalUrl">Any Url including those starting with ~</param>
	/// <returns>relative url</returns>
	public static string ResolveUrl(string originalUrl)
	{
		if (originalUrl == null)
			return null;

		// *** Absolute path - just return
		if (originalUrl.IndexOf("://") != -1)
			return originalUrl;

		// *** Fix up image path for ~ root app dir directory
		if (originalUrl.StartsWith("~"))
		{
			string newUrl = "";
			if (HttpContext.Current != null)
				newUrl = HttpContext.Current.Request.ApplicationPath +
						originalUrl.Substring(1).Replace("//", "/");
			else
				// *** Not context: assume current directory is the base directory
				throw new ArgumentException("Invalid URL: Relative URL not allowed.");

			// *** Just to be sure fix up any double slashes
			return newUrl;
		}

		return originalUrl;
	}

	public static bool IsActive(this PageModel page)
	{
		if (HttpContext.Current.Request.Url.LocalPath.Contains(page.UriTitle))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}