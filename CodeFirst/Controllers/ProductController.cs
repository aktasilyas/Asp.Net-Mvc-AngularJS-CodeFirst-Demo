using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context;
        public ProductController()
        {
            context = new Context();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll()
        {
            var result = context.Products.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Product product)
        {
            var addedEntiy = context.Entry(product);
            addedEntiy.State = EntityState.Added;
            var result = context.SaveChanges() > 0;

            return Json(result);
        }
        public JsonResult Delete(Product product)
        {
            var addedEntiy = context.Entry(product);
            addedEntiy.State = EntityState.Deleted;
            var result = context.SaveChanges() > 0;

            return Json(result);
        }
        public JsonResult Update(Product product)
        {
            var addedEntiy = context.Entry(product);
            addedEntiy.State = EntityState.Modified;
            var result = context.SaveChanges() > 0;

            return Json(result);
        }
    }
}