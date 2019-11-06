using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kala.Controllers
{
    public class KalaController : Controller
    {
        // GET: Kala
        public ActionResult Index()
        {
            return View();
        }
    }
}