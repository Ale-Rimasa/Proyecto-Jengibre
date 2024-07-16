using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListUseers()
        {
            List<Useer> oList = new List<Useer>();
            oList = new CN_Useers().List();

            return Json(new { data = oList },JsonRequestBehavior.AllowGet); 
        }
    }
}