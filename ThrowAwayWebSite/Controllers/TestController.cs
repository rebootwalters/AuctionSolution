using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using DataAccessLayer;

namespace ThrowAwayWebSite.Controllers
{
    public class TestController : Controller
    {
          public ActionResult Index()
        {
            using (ContextDAL ctx = new ContextDAL())
            {
                ctx.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuctionProject;Integrated Security=True";
                var data = ctx.GetProducts(0, 100);
                return View(data);
            }
        }

        public ActionResult Roles()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                return View(ctx.GetRoles(0, 100));
            }
        }

        
    }
}