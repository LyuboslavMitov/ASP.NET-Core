using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<StoreUser> _um;
		private readonly IHostingEnvironment _env;
		public StoreSeeder(StoreContext ctx, IHostingEnvironment env, UserManager<StoreUser> um)
		{
			_ctx = ctx;
			_env = env;
			_um = um;
		}
		public async Task SeedAsync()
		{
			_ctx.Database.EnsureCreated();


			StoreUser user = await _um.FindByEmailAsync("lmitov@store.com");
			if(user==null)
			{
				user = new StoreUser()
				{
					FirstName = "Lyuboslav",
					LastName = "Mitov",
					Email = "lmitov@store.com",
					UserName = "lmitov@store.com"
				};
				var result = await _um.CreateAsync(user,"P@ssw0rd!");
				if (result!=IdentityResult.Success)
				{
					throw new InvalidOperationException("Could not create user");
				}
			}

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
					order.User = user;
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
