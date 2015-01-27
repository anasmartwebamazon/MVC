using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Uni_Practice.Controllers
{
    public class EmptyController : Controller
    {
        //
        // GET: /Empty/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime EnrollDate)
        {
            var newDate = EnrollDate.ToShortDateString(); 
            ViewBag.Datetime = newDate;
            return View();
        }
	}
}