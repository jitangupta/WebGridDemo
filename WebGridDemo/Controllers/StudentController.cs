using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGridDemo.Context;
using WebGridDemo.Models;

namespace WebGridDemo.Controllers
{
    public class StudentController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // POST: Student Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Student searchOption)
        {
            string searchQuery = string.Empty;
            if (searchOption.Name == null)
                searchQuery = "select * from Student where";
            else
                searchQuery = "select * from Student where name like '%" + searchOption.Name + "%'";

            if (searchOption.Phone != null)
            {
                if (searchOption.Name != null)
                    searchQuery += " and phone like '%" + searchOption.Phone + "%'";
                else
                    searchQuery += " phone like '%" + searchOption.Phone + "%'";
            }

            if (searchOption.Address != null)
            {
                if (searchOption.Name != null || searchOption.Phone != null)
                    searchQuery += " and Address like '%" + searchOption.Address + "%'";
                else
                    searchQuery += " Address like '%" + searchOption.Address + "%'";
            }

            if (searchOption.Class != null)
            {
                if (searchOption.Name != null || searchOption.Phone != null || searchOption.Address != null)
                    searchQuery += " and Class like '%" + searchOption.Class + "%'";
                else
                    searchQuery += " Class like '%" + searchOption.Class + "%'";
            }

            if (searchOption.Name == null && searchOption.Phone == null && searchOption.Address == null && searchOption.Class == null)
                searchQuery = "select * from Student";

            //List<StudentDto> studentsDto = StudentList(searchQuery);
            var students = db.Students.SqlQuery(searchQuery).ToList();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Name,Phone,Address,Class,IsActive")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Name,Phone,Address,Class,IsActive")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
