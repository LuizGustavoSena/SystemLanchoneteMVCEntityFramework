using ProjMVCEntityPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjMVCEntityPizza.Dal
{
    public class PizzaInicializer : DropCreateDatabaseIfModelChanges<PizzaContext>
    {
        protected override void Seed(PizzaContext context)
        {
            var pizzas = new List<Pizza>
            {
                new Pizza{Id = 1, Descricao = "4 Queijos", Valor = 24},
                new Pizza{Id = 2, Descricao = "6 Queijos", Valor = 25},
            };

            pizzas.ForEach(x => context.Pizzas.Add(x));
            context.SaveChanges();
        }
    }
}