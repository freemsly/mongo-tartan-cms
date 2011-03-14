using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

namespace Tartan.Models
{
	#region Models
	public class PageModel
	{
		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Order")]
		public int Order { get; set; }

		[Required]
		[Display(Name = "Content")]
		public List<Module> Modules { get; set; }

		public string UriTitle
		{
			get
			{
				return Title.Replace(' ', '-');
			}
		}

		public virtual string ID { get; set; }
	}
	
	public abstract class Module
	{
		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; }

		[Required]
		[Display(Name="Order")]
		public int Order { get; set; }

	}

	public class ContentModule : Module
	{
		[Required]
		[Display(Name = "Content")]
		public string Content
		{
			get;
#if !DEBUG
			protected set;
#else
			set;
#endif
		}

	}

	public class ListModule : Module
	{
		public Dictionary<string, string> ListItems
		{
			get;
			set;
		}
	}
	#endregion Models
}