using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Repositories;
using DAL.Common;

namespace VNEXPRESS.Controllers
{
    public class AuthController : Controller
    {
        private UserRepository userRepository = null;

        public AuthController()
        {
            this.userRepository = new UserRepository();
        }

        public AuthController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var errors = new Dictionary<string, string>();
            var obj = userRepository.Get(x => x.Username == username).FirstOrDefault();

            if (Utils.IsNullOrEmpty(obj))
            {
                errors.Add("Username", "Username is not exists!");

                return Json(new
                {
                    statusCode = 400,
                    message = "Error",
                    data = errors
                }, JsonRequestBehavior.AllowGet);
            }

            if (!Utils.ValidatePassword(password, obj.Password))
            {
                errors.Add("Password", "Your password is wrong!");

                return Json(new
                {
                    statusCode = 400,
                    message = "Error",
                    data = errors
                }, JsonRequestBehavior.AllowGet);
            }

            Session["user"] = obj;

            return Json(new
            {
                statusCode = 200,
                message = "Success"
            }, JsonRequestBehavior.AllowGet);
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear(); //remove session
            return RedirectToAction("Login");
        }
    }
}