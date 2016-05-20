namespace ApiDemo2.Migrations
{
	using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiDemo2.DataAccess.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ApiDemo2.DataAccess.BlogContext";
        }

        protected override void Seed(ApiDemo2.DataAccess.BlogContext context)
        {

					context.Blogs.AddOrUpdate(
								 p => p.Name,
								 new Blog { Name = "BlogEsporte"},
								 new Blog { Name = "BlogMetal" },
								 new Blog { Name = "FoodForAll" }
							 );
          
						

        }
    }
}
