using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ComponentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //this method decides to what database our project is based on.
        {
            //  @ helps visual studio to understand "\" as "\", otherwise we should use "\\" instead of "\". Because "\" has a syntatic meaning in C#
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");

        }
    }
}
