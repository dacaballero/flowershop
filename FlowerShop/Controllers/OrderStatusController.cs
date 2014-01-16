using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class OrderStatusController : Controller
    {
        private FlowerShopContext db = new FlowerShopContext();

        //
        // GET: /OrderStatus/

        public ActionResult Index()
        {
            return View(db.OrderStatuses.ToList());
        }

        //
        // GET: /OrderStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderStatus orderstatus = db.OrderStatuses.Find(id);
            if (orderstatus == null)
            {
                return HttpNotFound();
            }
            return View(orderstatus);
        }

        //
        // GET: /OrderStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderStatus/Create

        [HttpPost]
        public ActionResult Create(OrderStatus orderstatus)
        {
            if (ModelState.IsValid)
            {
                db.OrderStatuses.Add(orderstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderstatus);
        }

        //
        // GET: /OrderStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderStatus orderstatus = db.OrderStatuses.Find(id);
            if (orderstatus == null)
            {
                return HttpNotFound();
            }
            return View(orderstatus);
        }

        //
        // POST: /OrderStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderStatus orderstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderstatus);
        }

        //
        // GET: /OrderStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderStatus orderstatus = db.OrderStatuses.Find(id);
            if (orderstatus == null)
            {
                return HttpNotFound();
            }
            return View(orderstatus);
        }

        //
        // POST: /OrderStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderStatus orderstatus = db.OrderStatuses.Find(id);
            db.OrderStatuses.Remove(orderstatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}