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
    public class CourseController : Controller
    {
        private UniversityManagementDbContext db = new UniversityManagementDbContext();

        // GET: /Course/
        public ActionResult ViewAllCourses()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semister);
            return View(courses.ToList());
        }

        // GET: /Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code");
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "Name");
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Code,Name,Credit,Description,DepartmentId,SemisterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("ViewAllCourses");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "Name", course.SemisterId);
            return View(course);
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "Name", course.SemisterId);
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Code,Name,Credit,Description,DepartmentId,SemisterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAllCourses");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "Name", course.SemisterId);
            return View(course);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("ViewAllCourses");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult IsCodeExist(string Code)
        {
            var isCodeExist = db.Courses.FirstOrDefault(c => c.Code==Code);

            if (isCodeExist != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsNameExist(string Name)
        {
            var isNameExist = db.Courses.FirstOrDefault(c => c.Name == Name);

            if (isNameExist != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public void GenerateDropDownList()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.TeacherId = new SelectList("", "TeacherId", "Name");
            ViewBag.CourseId = new SelectList("", "Id", "Name");
        }

        public ActionResult AssignCourse()
        {
            GenerateDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourse(int DepartmentId, int TeacherId)
        {
            GenerateDropDownList();
            return View();
        }
        ////[HttpPost]
        //public ActionResult AssignCourse(Course course)
        //{
        //    //GenerateDropDownList();
        //    return View();
        //}
    
        public JsonResult GetTeacherCourseByDepartmentId(int DepartmentId)
        {
            var teachrCourseList =
        from t in db.Teachers 
        join d in db.Departments on t.DepartmentId equals  d.Id
        join c in db.Courses on d.Id equals c.DepartmentId    
        where d.Id == DepartmentId 
        select new {  t.Id,t.Name,c.Code,Cid=c.Id };

//SELECT 
//    Teachers.Id,
//    Teachers.Name,
//    Courses.Code,
//    Courses.Id
//FROM 
//    Teachers 
//    INNER JOIN Departments on Teachers.DepartmentId=Departments.Id
//    INNER JOIN Courses on Departments.Id=Courses.DepartmentId
//WHERE 
//    Departments.Id=1;

       //     var q =
       //from c in categories
       //join p in products on c equals p.Category
       //select new { Category = c, p.ProductName }; 

            ViewBag.a = "a";
            //var teachrCourseList = db.Teachers.Where(a => a.DepartmentId == DepartmentId).ToList();
           // var teachrCourseList=db.Teachers join
            return Json(teachrCourseList, JsonRequestBehavior.AllowGet);
        }
        
    }
}
