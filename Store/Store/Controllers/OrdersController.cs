using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IStoreRepository db;

		public OrdersController(IStoreRepository repo)
		{
			db = repo;
		}
		public IActionResult Orders(int id)
		{
			if(id!=0)
			{
				//wrap it in a list for simplicity
				var order = db.GetOrder(id);
				if (order != null)
				{
					return View(order);
				}
			}
			//If the id is not found just show everything
			var result = db.GetAllOrders();
			return View(result);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		// Using entity model instead of View Model!!
		[HttpPost]
		public IActionResult Create(Order model)
		{
			db.AddEntity(model);
			return View();
		}
	}
}
