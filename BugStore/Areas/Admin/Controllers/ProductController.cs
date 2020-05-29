using BugStore.Areas.ViewModel;
using BugStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugStore.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DBBugstoreDataContext data = new DBBugstoreDataContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Listproduct()
        {
            var prod = from b in data.tbl_products 
                       join a in data.tbl_brands on b.id_brand equals a.id_brand
                       join c in data.tbl_categories on b.id_category equals c.id_category
                       select new ProductViewModel(){ 
                           name = b.name_product, 
                           image = b.image_product, 
                           cat = c.name_category, 
                           brand = a.name_brand , 
                           price =Convert.ToInt32(b.price_product) };
            return PartialView(prod);
        }
        public ActionResult Details(string id)
        {
            var prod = from b in data.tbl_products
                       join a in data.tbl_brands on b.id_brand equals a.id_brand
                       join c in data.tbl_categories on b.id_category equals c.id_category
                       where b.name_product == id
                       select new DetailsViewModel() {
                           name = b.name_product, 
                           image = b.image_product, 
                           cat = c.name_category, 
                           brand = a.name_brand, 
                           disc = b.discription_product,
                           price = Convert.ToInt32(b.price_product) };
            return View(prod.Single());
        }
        public ActionResult Size1Product(string id)
        {
            var prod = from b in data.tbl_products
                       where Convert.ToString(b.name_product) == id
                       select b;
            return View(prod);
        }
    }
}