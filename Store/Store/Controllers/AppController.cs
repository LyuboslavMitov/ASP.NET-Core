using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public class AppController :Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet("Contact")]
		public IActionResult Contact()
		{
			ViewBag.Title = "Contact us";
			
			return View();
		}
		[HttpPost("Contact")]
		public IActionResult Contact(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				//send email
			}
			ModelState.Clear();
			ViewBag.Message = "Your email has been sent :)";
			return View();
		}
		[HttpGet("About")]
		public IActionResult About()
		{
			ViewBag.Title = "About";
			return View();
		}
	}
}
