using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;


namespace PruebaPFC.Models
{
    public class ClienteClient
    {
        private readonly string Base_URL = "https://localhost:44341/api/";

        public IEnumerable<Cliente> BuscarTodos()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("clientesApi").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Cliente>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }


        public Cliente Buscar(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("ClientesApi/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Cliente>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }        


        public bool Editar(Cliente cliente)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("ClientesApi/" + cliente.ClienteId, cliente).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}