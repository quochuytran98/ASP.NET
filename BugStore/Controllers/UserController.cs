using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
                //ViewBag.Thongbao = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác !";
            }
            else
            {
                Session["customer"] = cus;
                Session["id_customer"] = cus.id_customer;
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
        [HttpGet]
        public ActionResult Register()
        {
            
          
            return View();
          
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection,tbl_customer cus) {
            var Username = collection["username"];
            var Name = collection["name"];
            var Password = collection["password"];
            var RepearPassword = collection["repeatpassword"];
            var Phone = collection["Phone"];
            var Email = collection["email"];
            var Address = collection["address"];

            if (data.tbl_customers.Any(c => c.username_customer ==Username))
            {
                ViewBag.Error = "Username tồn tại";
                
            }else if (data.tbl_customers.Any(c => c.email_customer == Email))
            {
                ViewBag.Error= "Email tồn tại";
            }
            else if (data.tbl_customers.Any(c => c.phone_customer == Convert.ToInt32(Phone)))
            {
                ViewBag.Error = "Phone tồn tại";
            }
            else if (Password!=RepearPassword)
            {
                ViewBag.Error = "Password Không trùng khớp";
            }
            else
            {
                //gán giá trị cho đối tượng tạo mới
                cus.username_customer = Username;
                cus.name_customer = Name;
                cus.password_customer = Password;
                cus.phone_customer = Convert.ToInt32(Phone);
                cus.email_customer = Email;
                cus.address_customer = Address;
                data.tbl_customers.InsertOnSubmit(cus);
                data.SubmitChanges();
                ViewBag.Success = "Đăng Ký Thành Công";
            }
            return View();
        }

    }
}