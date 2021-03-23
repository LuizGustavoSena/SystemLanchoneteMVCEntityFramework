using ProjMVCEntityPizza.Dal;
using ProjMVCEntityPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjMVCEntityPizza.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaContext db = new PizzaContext();
        // GET: Pizza
        public ActionResult Index()
        {
            return View(db.Pizzas.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Pizzas.First(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pizza pizza)
        {
            if (ModelState.IsValid){
                Pizza up = db.Pizzas.First(x => x.Id == pizza.Id);
                up.Descricao = pizza.Descricao;
                up.Valor = pizza.Valor;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Details(int id)
        {
            //return View(db.Pizzas.First(x => x.Id == id));
            return View(db.Pizzas.Find(id));
        }

        public ActionResult Delete(int id)
        {
            return View(db.Pizzas.First(x => x.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Pizza delete = db.Pizzas.First(x => x.Id == id);
            db.Pizzas.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}