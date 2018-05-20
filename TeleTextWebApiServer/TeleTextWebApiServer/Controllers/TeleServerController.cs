using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeleTextWebApiServer.Controllers
{
    public class TeleServerController : Controller
    {
        // GET: TeleServer
        public ActionResult StartServer()
        {
            return View();
        }
    }
}