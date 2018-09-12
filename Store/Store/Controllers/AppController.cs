using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public class AppController :Controller
	{
		private readonly IStoreRepository db;
		public AppController(IStoreRepository _db)
		{
			db = _db;
		}
		public IActionResult Index()
		{
			var products = db.GetAllProducts();
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
		[Authorize]
		public IActionResult Shop()
		{
			return View();
		}
	}
}
