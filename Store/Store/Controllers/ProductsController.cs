using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Data;
using Store.Data.Entities;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Produces("application/json")]
    public class ProductsController : ControllerBase
    {
		private readonly IStoreRepository db;
		private readonly ILogger<ProductsController> logger;
		public ProductsController(IStoreRepository _db, ILogger<ProductsController> _logger)
		{
			db = _db;
			logger = _logger;
		}
        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
			try
			{

			return Ok(db.GetAllProducts());
			}
			catch(Exception ex)
			{
				logger.LogError("Exception occured while calling get products: {0}",ex);
				return BadRequest("Failed to get products!");
			}
        }
    }
}
