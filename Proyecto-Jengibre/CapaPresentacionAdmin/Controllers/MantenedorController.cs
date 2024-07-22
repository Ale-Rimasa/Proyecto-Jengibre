using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult Mark()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListCategory()
        {
            List<Category> oList = new List<Category>();
            oList = new CN_Category().List();
            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveCategory(Category objeto) //Va a guardar y editar un usuario este metodo
        {
            object result; //Este tipo de dato almacena un string, entero o cualquier otro valor.
            string menssaje = string.Empty;

            if (objeto.ID_Category == 0)
            {

                result = new CN_Category().Register(objeto, out menssaje);
            }
            else
            {
                result = new CN_Category().Edit(objeto, out menssaje);
            }

            return Json(new { result = result, menssaje = menssaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminateCategory(int id) //Va a guardar y editar un usuario este metodo
        {
            bool eliminate = false;
            string menssaje = string.Empty;

            eliminate = new CN_Category().Eliminate(id, out menssaje);

            return Json(new { result = eliminate, menssaje = menssaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListMark()
        {
            List<Mark> oList = new List<Mark>();
            oList = new CN_Mark().List();
            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveMark(Mark objeto) //Va a guardar y editar un usuario este metodo
        {
            object result; //Este tipo de dato almacena un string, entero o cualquier otro valor.
            string menssaje = string.Empty;

            if (objeto.ID_Mark == 0)
            {

                result = new CN_Mark().Register(objeto, out menssaje);
            }
            else
            {
                result = new CN_Mark().Edit(objeto, out menssaje);
            }

            return Json(new { result = result, menssaje = menssaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminateMark(int id) //Va a guardar y editar un usuario este metodo
        {
            bool eliminate = false;
            string menssaje = string.Empty;

            eliminate = new CN_Mark().Eliminate(id, out menssaje);

            return Json(new { result = eliminate, menssaje = menssaje }, JsonRequestBehavior.AllowGet);
        }
    }
}