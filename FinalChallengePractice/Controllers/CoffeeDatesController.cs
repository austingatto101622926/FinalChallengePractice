using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalChallengePractice.Models;

namespace FinalChallengePractice.Controllers
{
    [Authorize(Roles = "Authorised")]
    public class CoffeeDatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CoffeeDates
        public ActionResult Index()
        {
            return View(db.CoffeeDates.Where(C => C.DateTime > DateTime.Now).ToList());
        }

        // GET: CoffeeDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeDate coffeeDate = db.CoffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeeDate);
        }

        // GET: CoffeeDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoffeeDateId,DateTime,Venue")] CoffeeDate coffeeDate)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeDates.Add(coffeeDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeDate);
        }

        // GET: CoffeeDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeDate coffeeDate = db.CoffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeeDate);
        }

        // POST: CoffeeDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoffeeDateId,DateTime,Venue")] CoffeeDate coffeeDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeDate);
        }

        // GET: CoffeeDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeDate coffeeDate = db.CoffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeeDate);
        }

        // POST: CoffeeDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeDate coffeeDate = db.CoffeeDates.Find(id);
            db.CoffeeDates.Remove(coffeeDate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
