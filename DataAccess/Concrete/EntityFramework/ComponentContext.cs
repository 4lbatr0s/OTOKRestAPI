using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ComponentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //this method decides to what database our project is based on.
        {
            //  @ helps visual studio to understand "\" as "\", otherwise we should use "\\" instead of "\". Because "\" has a syntatic meaning in C#
            optionsBuilder.UseSqlServer(@"Server=BRCK623;Database=OtokDB;Trusted_Connection=true");

        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentImage> ComponentImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
