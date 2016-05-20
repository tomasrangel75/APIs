using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Post
	{
		private Post()
		{
			PostDate = System.DateTime.Now;
		}

		public int Id { get; set; }

		[Required(ErrorMessage="A Title is required")]
		[DisplayName("Post Title")]
		[Range(3, 20)]
		public string Title { get; set; }

		[DisplayName("Post Date")]
		public DateTime PostDate { get; set; }

		[Required(ErrorMessage = "A Publisher Name is required")]
		[DisplayName("Post Title")]
		[Range(3, 20)]
		public string Publisher { get; set; }
		
		public int IdBlog { get; set; }
		public virtual Blog PostBlog { get; set; }

	}
}
