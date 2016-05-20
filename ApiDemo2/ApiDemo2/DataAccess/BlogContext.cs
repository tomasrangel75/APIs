using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo2.DataAccess
{
	public class BlogContext : DbContext 
	{
		public BlogContext()
			: base("BlogContext")
		{

		}
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }

	}
}
