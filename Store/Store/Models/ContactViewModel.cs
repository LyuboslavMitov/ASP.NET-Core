﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class ContactViewModel
	{
		[Required]
		[MinLength(4)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Subject { get; set; }
		[Required]
		[MaxLength (500, ErrorMessage = "Too long")]
		public string Message { get; set; }

	}
}
