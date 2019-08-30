using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;using WebApplication2.Areas.Admin.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               
            }

            return View("index");
        }
    }
}