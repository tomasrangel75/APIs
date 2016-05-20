using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	    public class Blog
    {
			public int Id { get; set; }

			[Required(ErrorMessage="A Blog Name is required")]
		  [DisplayName("Blog Name")]
			//[Range(3,20)]
			public string Name { get; set; }

			public virtual List<Post> Posts { get; set; }
    }
}
