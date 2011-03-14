using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Configuration;
using Tartan.Models;

namespace Tartan.Services.Mongo
{
	public static class Data
	{
		public static MongoDB.Mongo GetDB()
		{
			var config = new MongoConfigurationBuilder();

			config.Mapping(mapping => {
				mapping.DefaultProfile(profile =>
				{
					profile.SubClassesAre(x => x.IsSubclassOf(typeof(Module)));
				});

				mapping.Map<ContentModule>();
				mapping.Map<ListModule>();
			});

			config.ConnectionString("mongodb://localhost");

			MongoDB.Mongo mongo = new MongoDB.Mongo(config.BuildConfiguration());

			mongo.Connect();

			return mongo;
		}
	}
}