﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.Enities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
