using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace LoginFormAUTH.Controllers
{

    [Authorize]
    public class EmployeeBIOsController : Controller
    {
        private testEntities db = new testEntities();

        // GET: EmployeeBIOs
        public ActionResult Index()
        {
            return View(db.EmployeeBIOs.ToList());
        }

        // GET: EmployeeBIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBIO employeeBIO = db.EmployeeBIOs.Find(id);
            if (employeeBIO == null)
            {
                return HttpNotFound();
            }
            return View(employeeBIO);
        }

        // GET: EmployeeBIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeBIOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Designation,Salary")] EmployeeBIO employeeBIO)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeBIOs.Add(employeeBIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeBIO);
        }

        // GET: EmployeeBIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBIO employeeBIO = db.EmployeeBIOs.Find(id);
            if (employeeBIO == null)
            {
                return HttpNotFound();
            }
            return View(employeeBIO);
        }

        // POST: EmployeeBIOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Designation,Salary")] EmployeeBIO employeeBIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeBIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeBIO);
        }

        // GET: EmployeeBIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBIO employeeBIO = db.EmployeeBIOs.Find(id);
            if (employeeBIO == null)
            {
                return HttpNotFound();
            }
            return View(employeeBIO);
        }

        // POST: EmployeeBIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeBIO employeeBIO = db.EmployeeBIOs.Find(id);
            db.EmployeeBIOs.Remove(employeeBIO);
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
