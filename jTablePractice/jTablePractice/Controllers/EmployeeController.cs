using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jTablePractice.Models;

namespace jTablePractice.Controllers
{
    public class EmployeeController : Controller
    {
        private RepoContext db = new RepoContext();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }


        public JsonResult EmployeeList(int jtStartIndex, int jtPageSize)
        {
            try
            {
                var empCount = db.Employees.Count();
                var emps = db.Employees.ToList().Distinct().Skip(jtStartIndex).Take(jtPageSize);
                return Json(new { Result = "OK", Records = emps, TotalRecordCount = empCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
           // GET: /Student/Create
        [HttpPost]
        public JsonResult CreateEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Json(new { Result = "OK", Record = employee });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteEmployee(int EmployeeId)
        {
            try
            {
                var std = db.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
                db.Employees.Remove(std);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EditEmployee(Employee employee)
        {
            try
            {
                   // var std = db.Students.FirstOrDefault(x => x.StudentId==student.StudentId);
                    db.Employees.AddOrUpdate(employee);
                    db.SaveChanges();
                    return Json(new { Result = "OK", Record = employee });
   
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
