using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo1.DataAccess.Models
{
	public class Student
	{
		public int Id { get; set; }


		[Required(ErrorMessage = "Required Field")]
		//[StringLength(50, MinimumLength = 3)]
		[RegularExpression(@"\d{3,20}",ErrorMessage="First Name must be between 3 and 20 chars" )]
		[Display(Name="First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Required Field")]
		//[StringLength(50, MinimumLength = 3)]
		[RegularExpression(@"\d{3,20}", ErrorMessage = "Last Name must be between 3 and 20 chars")]
		[Display(Name = "Last Name")]
    public string LastName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Required(ErrorMessage = "Required Field")]
		[Display(Name = "Birth Date")]
		public System.DateTime BirthDate { get; set; }

		[Display(Name = "Full Name")]
		public string Name
		{
			get
			{
				return string.Format("{0} {0}", this.FirstName, this.LastName);
			}
		}

			[Display(Name = "Age")]
		public int Age
		{
			get
			{

				DateTime dtNow = DateTime.Today;
				int curAge = dtNow.Year - BirthDate.Year;
				if (BirthDate > dtNow.AddYears(-curAge))
				{
					curAge--;
				};
				return curAge;

			}

		}

		[Required(ErrorMessage = "Required Field")]
		[EmailAddress]
		[Display(Name = "Email Address")]
			public string Email { get; set; }

	}
}
