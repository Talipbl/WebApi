using ApiDataAccess.Models;
using MvcUi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUi.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities _db = new NorthwindEntities();
        // GET: Home
        public ActionResult ListProducts()
        {
            return View();
        }
    }
}