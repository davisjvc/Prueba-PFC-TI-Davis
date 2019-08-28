using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Servicios;
using Servicios.Models;
using Servicios.DataAccess;

namespace Servicios.Controllers
{
    public class OrdenesApiController : ApiController
    {

        private OrdenDataAccess db = new OrdenDataAccess();

        // GET: api/OrdenesApi/5
        public IEnumerable<Orden> GetOrdenes(int id)
        {
            List<Orden> lstOrdenes = db.ConsultarOrdenes(id);
            if (lstOrdenes == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lstOrdenes;
        }

        // DELETE: api/ClientesApi/5
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCliente(int id)
        {
            int count = 0;

            try
            {
                count = db.EliminarOrden(id);
                if (count > 0)
                    return Ok();
                else
                    return NotFound();
            }
            catch (DBConcurrencyException)
            {
                if (count == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
        }
    }
}
