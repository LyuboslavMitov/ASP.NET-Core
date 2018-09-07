﻿using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
	public class StoreSeeder
	{
		private readonly StoreContext _ctx;

		private readonly IHostingEnvironment _env;
		public StoreSeeder(StoreContext ctx, IHostingEnvironment env)
		{
			_ctx = ctx;
			_env = env;
		}
		public void Seed()
		{
			_ctx.Database.EnsureCreated();
			if (!_ctx.Products.Any())
			{
				//Need to create sample data
				var filepath = Path.Combine(_env.ContentRootPath, "Data/art.json");
				var json = File.ReadAllText(filepath);
				var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
				_ctx.Products.AddRange(products);

				var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
				if (order != null)
				{
					order.Items = new List<OrderItem>()
					{
						new OrderItem()
						{
						Product = products.First(),
						Quantity = 5,
						UnitPrice = products.First().Price
						}
					};
				}
				_ctx.SaveChanges();
			}
		}

	}
}
