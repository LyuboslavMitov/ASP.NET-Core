﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
	public string MotherName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
