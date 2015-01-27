using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uni_Practice.Models;

namespace Uni_Practice.Controllers
{
    public class CourseStudentEnrollmentController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /CourseStudentEnrollment/
        public ActionResult Index()
        {
            var coursestudentenrolls = db.CourseStudentEnrolls.Include(c => c.Course).Include(c => c.Student);
            return View(coursestudentenrolls.ToList());
        }

        // GET: /CourseStudentEnrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudentEnroll coursestudentenroll = db.CourseStudentEnrolls.Find(id);
            if (coursestudentenroll == null)
            {
                return HttpNotFound();
            }
            return View(coursestudentenroll);
        }

        // GET: /CourseStudentEnrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationNo");
            return View();
        }

        // POST: /CourseStudentEnrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseStudentEnrollId,CourseId,StudentId,EnrollDate,Session")] CourseStudentEnroll coursestudentenroll)
        {
            if (ModelState.IsValid)
            {
                if (!AlreadyEnrolled(coursestudentenroll))
                {
                    coursestudentenroll.EnrollDate = coursestudentenroll.EnrollDate.Date;
                    db.CourseStudentEnrolls.Add(coursestudentenroll);
                    db.SaveChanges();
                    ViewBag.Messege = "";
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.Messege = "This Enrollment has already inserted";
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", coursestudentenroll.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationNo", coursestudentenroll.StudentId);
            return View(coursestudentenroll);
        }

        private bool AlreadyEnrolled(CourseStudentEnroll coursestudentenroll)
        {
            var enr =
                db.CourseStudentEnrolls.FirstOrDefault(
                    x => x.StudentId == coursestudentenroll.StudentId && x.CourseId == coursestudentenroll.CourseId);
            if (enr == null)
                return false;
            return true;
        }

        // GET: /CourseStudentEnrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudentEnroll coursestudentenroll = db.CourseStudentEnrolls.Find(id);
            if (coursestudentenroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", coursestudentenroll.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationNo", coursestudentenroll.StudentId);
            return View(coursestudentenroll);
        }

        // POST: /CourseStudentEnrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseStudentEnrollId,CourseId,StudentId,EnrollDate,Session,ObtainedNumber")] CourseStudentEnroll coursestudentenroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursestudentenroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", coursestudentenroll.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegistrationNo", coursestudentenroll.StudentId);
            return View(coursestudentenroll);
        }

        // GET: /CourseStudentEnrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseStudentEnroll coursestudentenroll = db.CourseStudentEnrolls.Find(id);
            if (coursestudentenroll == null)
            {
                return HttpNotFound();
            }
            return View(coursestudentenroll);
        }

        // POST: /CourseStudentEnrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseStudentEnroll coursestudentenroll = db.CourseStudentEnrolls.Find(id);
            db.CourseStudentEnrolls.Remove(coursestudentenroll);
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
