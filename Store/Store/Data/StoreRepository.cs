using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
	public class StoreRepository : IStoreRepository
	{
		private readonly StoreContext ctx;
		private readonly ILogger<StoreRepository> logger;
		public StoreRepository(StoreContext _ctx, ILogger<StoreRepository> _logger)
		{
			ctx = _ctx;
			logger = _logger;
		}

		public void AddEntity(object model)
		{
			try
			{
				ctx.Add(model);
			}
			catch(Exception ex)
			{
				logger.LogError("Failed to execute AddEntity: " + ex);
			}
		}

		public IEnumerable<Order> GetAllOrders()
		{
			try
			{
				return ctx.Orders
					.Include(o => o.Items)
					.ThenInclude(i=>i.Product)
					.ToList();
			}
			catch(Exception ex)
			{
				logger.LogError("Failed to execute GetAllProducts: " + ex);
				return null;
			}
		}

		public IEnumerable<Product> GetAllProducts()
		{
			try {
					return ctx.Products.OrderBy(p => p.Title);
				}
			catch(Exception ex)
			{
				logger.LogError("Failed to execute GetAllProducts: "+ex);
				return null;
			}
		}

		public Order GetOrder(int id)
		{
			try
			{
				return ctx.Orders
					.Include(o => o.Items)
					.ThenInclude(i => i.Product)
					.Where(o => o.Id == id)
					.FirstOrDefault();
			}
			catch (Exception ex)
			{
				logger.LogError("Failed to execute GetOrder: " + ex);
				return null;
			}
		}

		public IEnumerable<Product> GetProductsByCategory(string Category)
		{
			return ctx.Products.Where(c => c.Category == Category);
		}
		public bool Save()
		{
			return ctx.SaveChanges() > 0;
		}
	}
}
