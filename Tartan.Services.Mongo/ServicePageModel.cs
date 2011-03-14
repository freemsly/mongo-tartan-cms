using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tartan.Models;
using MongoDB;

namespace Tartan.Services.Mongo
{
	public class ServicePageModel : PageModel
	{
		public Oid Id { get; set; }
	}
}
