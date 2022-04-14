//using System;
//using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_project_2021.Models;

namespace IT_project_2021.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CustomersController : Controller
    {
        private CustomersContext dbCustomers = new CustomersContext();



        // GET: Customers
        public ActionResult Index()
        {

            return View(dbCustomers.Customers.OrderBy(c => c.CustomerId).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersModel customers = dbCustomers.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,CustomerName,PhoneNumber,DateOfBirth,Age,YearsExp")] CustomersModel customers)
        {
            if (ModelState.IsValid)
            {
                dbCustomers.Customers.Add(customers);
                dbCustomers.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersModel customers = dbCustomers.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,CustomerName,PhoneNumber,DateOfBirth,Age,YearsExp")] CustomersModel customers)
        {
            if (ModelState.IsValid)
            {
                dbCustomers.Entry(customers).State = EntityState.Modified;
                dbCustomers.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersModel customers = dbCustomers.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomersModel customers = dbCustomers.Customers.Find(id);
            dbCustomers.Customers.Remove(customers);
            dbCustomers.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbCustomers.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
