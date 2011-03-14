using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tartan.Common
{
	public class Helpers
	{
		public static bool PropertyExists(object dynamicObject, string propertyName)
		{
			var propertyExists = dynamicObject.GetType().GetProperties().Where(
				p => p.Name == propertyName).Count() > 0;

			return propertyExists;
		}
	}
}
