using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeePower.Models;

namespace EmployeePower.Controllers
{
    public class EmployeeController : Controller
    {
        private DB_Emp_PowerEntities db = new DB_Emp_PowerEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Tbl_Employee_Login_Details.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee_Login_Details tbl_Employee_Login_Details = db.Tbl_Employee_Login_Details.Find(id);
            if (tbl_Employee_Login_Details == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Login_Details);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Emp_FirstName,Emp_LastName,Emp_Email,Emp_Email_Confirm,Emp_MobileNo,Emp_MobilieNo_Confirm,Emp_Alt_MobileNo,Emp_Password_Hash,Emp_Account_Status,Emp_Created_By,Emp_Created_Date,Emp_Updated_By,Emp_Updated_Date")] Tbl_Employee_Login_Details tbl_Employee_Login_Details)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Employee_Login_Details.Add(tbl_Employee_Login_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Employee_Login_Details);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee_Login_Details tbl_Employee_Login_Details = db.Tbl_Employee_Login_Details.Find(id);
            if (tbl_Employee_Login_Details == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Login_Details);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Emp_FirstName,Emp_LastName,Emp_Email,Emp_Email_Confirm,Emp_MobileNo,Emp_MobilieNo_Confirm,Emp_Alt_MobileNo,Emp_Password_Hash,Emp_Account_Status,Emp_Created_By,Emp_Created_Date,Emp_Updated_By,Emp_Updated_Date")] Tbl_Employee_Login_Details tbl_Employee_Login_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Employee_Login_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Employee_Login_Details);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee_Login_Details tbl_Employee_Login_Details = db.Tbl_Employee_Login_Details.Find(id);
            if (tbl_Employee_Login_Details == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Login_Details);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Employee_Login_Details tbl_Employee_Login_Details = db.Tbl_Employee_Login_Details.Find(id);
            db.Tbl_Employee_Login_Details.Remove(tbl_Employee_Login_Details);
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
