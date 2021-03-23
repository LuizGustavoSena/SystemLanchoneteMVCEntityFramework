using ProjMVCEntityPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjMVCEntityPizza.Dal
{
    public class PizzaContext : DbContext
    {
        public PizzaContext() : base("PizzaContext")
        {

        }
        public DbSet<Pizza> Pizzas { set; get; }
    }
}