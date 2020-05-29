using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugStore.Models;

namespace BugStore.Controllers
{

    public class UserController : Controller
    {
        DBBugstoreDataContext data = new DBBugstoreDataContext();
        // GET: User
        public ActionResult Index()
        {
            //var user = Session["user"];
            //if (user==null)
            //{
            //    return RedirectToAction("Login", "User");
            //}
            return View();
        }

        public ActionResult Login(FormCollection collection, tbl_customer cus)
        {
            var username = collection["username"];
            var password = collection["password"];
            //if (string.IsNullOrEmpty(username))
            //{
            //    ViewData["loi1"] = "Không Được Bỏ Trống Username";
            //}else if (string.IsNullOrEmpty(password))
            //{
            //    ViewData["loi2"] = "Không Được Bỏ Trống Password";
            //}
            //else
            //{
            cus = data.tbl_customers.SingleOrDefault(c => (c.username_customer == username || 
            c.email_customer==username) &&
            c.password_customer == password);
            if (cus == null)
            {
                ViewData["Thongbao"] = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác !";
            }
            else
            {
                Session["user"] = cus;
                return RedirectToAction("Index", "BugStore");
            }
            


            return View();
            //}

        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}