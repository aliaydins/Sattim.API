using Microsoft.EntityFrameworkCore;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.DataAccess
{
    public class UserDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //
            //Server=.\\SQLSERVER;  Database=SattimDb; Integrated Security=true;

            optionsBuilder.UseSqlServer("data source = aaydin.database.windows.net; Initial catalog = SattimDb; user id = aaydin; password = 123qwe..; MultipleActiveResultSets = True;");
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
