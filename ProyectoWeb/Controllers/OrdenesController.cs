using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        public ActionResult Index(int id)
        {
            return View();
        }

        public JsonResult GetAllJSON(int id)
        {
            OrdenesClient oc = new OrdenesClient();
            var ordenes = oc.BuscarTodos(id).ToList();

            return Json(ordenes, JsonRequestBehavior.AllowGet);
        }



        public HttpStatusCodeResult Delete(int id)
        {
            OrdenesClient oc = new OrdenesClient();
            if (oc.Eliminar(id))
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }




    }
}