using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
	public interface IStoreRepository
	{
		IEnumerable<Product> GetAllProducts();
		IEnumerable<Product> GetProductsByCategory(string Category);
		IEnumerable<Order> GetAllOrders();
		Order GetOrder(int id);

		void AddEntity(object model);
		bool Save();
	}
}
