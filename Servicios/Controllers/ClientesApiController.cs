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
    public class ClientesApiController : ApiController
    {
        private ClienteDataAccess db = new ClienteDataAccess();

        // GET: api/ClientesApi
        public IEnumerable<Cliente> GetClientes()
        {
            return db.ConsultarClientes();
        }

        // GET: api/ClientesApi/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.ConsultarCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/ClientesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            int count = 0;

            try
            {
                count = db.ActualizarCliente(cliente);
                if (count > 0)
                    return Ok();
                else
                    return NotFound();
            }
            catch (DbUpdateConcurrencyException)
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