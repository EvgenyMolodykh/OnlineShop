﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Product
    {

        static private int _instanceCounter = 0;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }

    }
}
