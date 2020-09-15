using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvesisTestWebApplication.Models
{
	public class RegisterViewModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Confirmation password and password do not match")]
		public string ConfirmPassword { get; set; }
	}
}
