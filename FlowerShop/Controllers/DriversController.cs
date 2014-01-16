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
    public class DriversController : Controller
    {
        private FlowerShopContext db = new FlowerShopContext();

        //
        // GET: /Driver/

        public ActionResult Index()
        {
            return View(db.Drivers.Where(x=>x.Active == true).ToList());
        }

        //
        // GET: /Driver/Details/5

        public ActionResult Details(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // GET: /Driver/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Driver/Create

        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                driver.DateAdded = DateTime.Now;
                driver.DateModified = DateTime.Now;
                driver.Active = true;

                db.Drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driver);
        }

        //
        // GET: /Driver/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Driver/Edit/5

        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                driver.DateModified = DateTime.Now;

                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        //
        // GET: /Driver/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Driver/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Drivers.Find(id);
            driver.Active = false;

            db.Entry(driver).State = EntityState.Modified;
            
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