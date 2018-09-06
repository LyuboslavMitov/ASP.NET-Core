using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
	public class StoreContext : DbContext
	{

		public StoreContext(DbContextOptions<StoreContext> options)
			: base(options)
		{
			
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

	}
}
