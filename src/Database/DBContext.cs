﻿using Microsoft.EntityFrameworkCore;

namespace services_order_delete.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Models.Orders> Orders { get; set; }
    }
}
