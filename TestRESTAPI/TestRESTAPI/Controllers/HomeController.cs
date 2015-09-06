using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestRESTAPI.Models;

namespace TestRESTAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ListItems()
        {
            List<MyItem> data = new List<MyItem>();

            using ( var db = new TestDBEntities())
            {
                var temp = db.Items.ToList();

                foreach(Item itm in temp)
                {
                    MyItem newitem = new MyItem();
                    newitem.ID = itm.ID;
                    newitem.Value = itm.Value;

                    data.Add(newitem);
                }
            }

            return View(data);
        }
    }
}
