using System;
using System.Collections;
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
        [HttpPost]
        public JsonResult SaveUseers(Useer objeto) //Va a guardar y editar un usuario este metodo
        {
            object result; //Este tipo de dato almacena un string, entero o cualquier otro valor.
            string menssaje = string.Empty;

            if(objeto.ID_User == 0)
            {

                result = new CN_Useers().Register(objeto, out menssaje);
            }
            else
            {
                result = new CN_Useers().Edit(objeto, out menssaje);
            }

            return Json(new { result = result, menssaje = menssaje }, JsonRequestBehavior.AllowGet);
        }
    }
}