﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataBaseContext (DbContextOptions<DataBaseContext> options):base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
