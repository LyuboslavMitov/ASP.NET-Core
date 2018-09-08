using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<StoreUser> signInManager;
		public AccountController(SignInManager<StoreUser> _signInManager)
		{
			signInManager = _signInManager;
		}
		public IActionResult Login()
		{
			if(this.User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "App");
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result =  await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,false);
				if(result.Succeeded)
				{
					if (Request.Query.Keys.Contains("ReturnUrl"))
					{
						RedirectToAction(Request.Query["ReturnUrl"].First());
					}
					
					return RedirectToAction("Shop","App");
				}
			}
			ModelState.AddModelError("", "Failed to login");
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "App");
		}
	}
}
