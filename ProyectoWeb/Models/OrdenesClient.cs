using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProyectoWeb.Models
{
    public class OrdenesClient
    {
        private readonly string Base_URL = "https://localhost:44341/api/";

        public IEnumerable<Orden> BuscarTodos(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("ordenesApi/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Orden>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("ordenesApi/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}