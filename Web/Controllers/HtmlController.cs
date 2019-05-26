using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HtmlController : Controller
    {
        // GET: Html
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}