using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using Tartan.Common;

namespace Tartan.Tests
{
	[TestClass]
	public class CommonTests
	{
		[TestMethod]
		public void TestPropertyExistsWithDynamic()
		{
			dynamic myTestObj = new {PropertyThatExists = "X" };

			Assert.IsTrue(myTestObj.PropertyThatExists == "X");
			Assert.IsTrue(Helpers.PropertyExists(myTestObj, "PropertyThatExists"));
		}
	}
}
