using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private UniversityManagementDbContext db = new UniversityManagementDbContext();

        // GET: /Teacher/
        public ActionResult ViewAllTeacher()
        {
            var teachers = db.Teachers.Include(t => t.Department).Include(t => t.Designation);
            return View(teachers.ToList());
        }

        // GET: /Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: /Teacher/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name");
            return View();
        }

        // POST: /Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Address,Email,ContactNo,DesignationId,DepartmentId,TakenCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return RedirectToAction("ViewAllTeacher");                   
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", teacher.DesignationId);       
            return View(teacher);
        }

        // GET: /Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", teacher.DesignationId);
            return View(teacher);
        }

        // POST: /Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Address,Email,ContactNo,DesignationId,DepartmentId,TakenCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAllTeacher");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", teacher.DesignationId);
            return View(teacher);
        }

        // GET: /Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("ViewAllTeacher");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult IsEmailExist(string Email)
        {
            var isEmailExist = db.Teachers.FirstOrDefault(t => t.Email == Email);
            if (isEmailExist != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
