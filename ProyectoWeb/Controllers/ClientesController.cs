using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaPFC.Models;
using PruebaPFC.ViewModels;

namespace PruebaPFC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Customer  
        public ActionResult Index()
        {
            return View();
        }
        

        public JsonResult GetAllJSON()
        {
            ClienteClient CC = new ClienteClient();
            var clientes = CC.BuscarTodos().ToList();

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }        
                

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClienteClient CC = new ClienteClient();
            ClienteViewModel CVM = new ClienteViewModel();
            CVM.cliente = CC.Buscar(id);
            return View("Edit", CVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClienteViewModel CVM)
        {
            ClienteClient CC = new ClienteClient();
            CC.Editar(CVM.cliente);
            return RedirectToAction("Index");
        }
    }
}