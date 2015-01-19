using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using jTablePractice.Models;

namespace jTablePractice.Controllers
{
    public class StudentController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public JsonResult StudentList()
        {
            try
            {
                var students = db.Students.ToList();
                return Json(new { Result = "OK", Records = students });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        // GET: /Student/Details/5
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

        // GET: /Student/Create
        [HttpPost]
        public JsonResult CreateStudent(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return Json(new { Result = "OK", Record = student });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteStudent(int StudentId)
        {
            try
            {
                var std=db.Students.FirstOrDefault(x=>x.StudentId==StudentId);
                db.Students.Remove(std);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EditStudent(Student student)
        {
            try
            {
                   // var std = db.Students.FirstOrDefault(x => x.StudentId==student.StudentId);
                    db.Students.AddOrUpdate(student);
                    db.SaveChanges();
                    return Json(new { Result = "OK", Record = student });
   
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
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
