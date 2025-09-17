using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthTest.Models;

namespace UserAuthTest.Controllers
{
    public class HomeController : Controller
    {
        TestDBEntities db = new TestDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            var oUser = db.Users.Where(w => w.Username == user.Username && w.Password == user.Password).FirstOrDefault();
            if (oUser != null)
            {
                Session["User"] = oUser;
                return RedirectToAction("Index", "Students");
            }
            
            return View();
        }

        
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}