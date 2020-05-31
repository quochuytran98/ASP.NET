using BugStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugStore.Controllers
{
    public class BugStoreController : Controller
    {
        DBBugstoreDataContext data = new DBBugstoreDataContext();
        public ActionResult Index()
        {
            var product = Listfeatured();
            return View(product);
        }
        private List<tbl_product> Listfeatured()
        {
            var ketqua = (from dp in data.tbl_products
                         where dp.type_product == 1
                         select dp);
            return ketqua.ToList();
        }
        public ActionResult ShowBrand()
        {
            var brand = from b in data.tbl_brands select b;
            return PartialView(brand);
        }
        public ActionResult Shop()
        {
            var pro = from p in data.tbl_products select p;
            return View(pro);
        }
        
    }
}